using System;
using System.Globalization;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using DigiKalaShop.SysCoreServices.PropellantServices.CoreAttributes;
using DigiKalaShop.ViewModels.OTP;
using DigiKalaShop.ViewModels.Users;
using DigiShop.AppService.SignInlogServices;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DNTCaptcha.Core;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace DigiShop.Controllers
{
    public class AccountController : Controller
    {
        
        private IUnitOfWork _work;
        private IAccountService _accountService;
        private IMapper _mapper;
        private IOtpService _otpService;
        private IMessageService _messageService;
        private ISignInLog _signInLog;
        private IAccessPermissionService _accessPermissionService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IUnitOfWork work, IAccountService accountService, IMapper mapper,
            IOtpService otpService, IMessageService messageService, IAccessPermissionService accessPermissionService,
            ISignInLog signInLog,ILogger<AccountController> logger)
        {
            _work = work;
            _accountService = accountService;
            _mapper = mapper;
            _otpService = otpService;
            _messageService = messageService;
            _accessPermissionService = accessPermissionService;
            _signInLog = signInLog;
            _logger = logger;
        }
       public AccountController(IAccountService accountService)
       {
           _accountService = accountService;
        }


        [HttpGet]
        public async Task<IActionResult> Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel? model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var IsPhoneExistsAsync = await _accountService.IsPhonenumberExistsAsync(model.Phonenumber);
                    var user = await _accountService.GetUserAsync(model.Phonenumber);
                    if (IsPhoneExistsAsync && user.UserStatus != UserStatus.None)
                    {
                        model.IsCompleted = false;
                        model.Message = "این نام کاربری قبلا ثبت نام کرده";
                        ModelState.AddModelError(nameof(model.Phonenumber), model.Message);
                        return View(model);
                    }

                    var code = _otpService.GenerateOtpCode(6);
                    var otp = new Otp();
                    otp.code = code;
                    if (user == null)
                    {
                        user = new User();
                        var roleId = _accessPermissionService.SearchRoleAsync(model.role);
                        user.roleId = roleId;
                        user.UserStatus = UserStatus.None;
                        _mapper.Map(model, user);
                        await _accountService.SignupUserAsync(user);
                    }

                    otp.User = user;
                    await _otpService.AddNewOtpCodeAsync(otp);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        //BackgroundJob.Enqueue(() => SendActivationCode(code,user.Phonenumber));
                        return RedirectToAction("Verify", new {phonenumber = user.Phonenumber});
                    }

                    model.IsCompleted = false;
                    model.Message = "خطا در پاسخگویی";
                    return View(model);
                    
                }
                catch (Exception e)
                {
                  _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }

        public async Task SendActivationCode(string code, string recptor)
        {
            await _messageService.SendMessageAsync("Digishop", recptor, code);
        }
        
        [HttpGet]
        [ResponseCache(VaryByHeader = "user-agent",Duration = 0,NoStore = true,Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> login()
        {
            return View();
        }

        [HttpPost]
        [ValidateDNTCaptcha(ErrorMessage = "کد امنیتی را صحیح وارد نمایید",
            CaptchaGeneratorLanguage = Language.Persian,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)] 
      
        public async Task<IActionResult> login(loginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _accountService.LoginUserAsync(model.Phonenumber, model.Password); 
                    if (user == null)
                    {
                        ModelState.AddModelError(nameof(user.Phonenumber), "کاربر پیدا نشد ");
                        return View(model);
                    }

                    if (user.UserStatus == UserStatus.Inactive)
                    {
                        ModelState.AddModelError(nameof(user.Phonenumber), "کاربر فعال نیست");
                        return View(model);
                    }
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Phonenumber));
                    claimsIdentity.AddClaim(new Claim("Userserial", user.Userserial));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.id.ToString()));
                    if (user.roleId == 1)
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));

                    else if (user.roleId == 2)
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "manager"));
                    else if (user.roleId == 4)
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "seller"));

                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "user"));

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    if (user.Role.rolename == "admin" || user.Role.rolename == "manager" || user.Role.rolename == "seller")
                        return RedirectToAction("DashBoard", "Admin");

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("login");
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string? phonenumber)
        {
            var otp = new OtpViewModel();
            otp.phonenumber = phonenumber;
            return View(otp);
        }

        [HttpPost]
        public async Task<IActionResult> Verify(OtpViewModel? model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var otp = await _otpService.GetOtpCodeAsync(model.code);
                    var user = await _accountService.GetUserAsyncById(otp.userId);
                    if (otp.IsAuthentic)
                    {
                        user.UserStatus = UserStatus.Active;
                        otp.IsUsed = true;
                        var row = await _work.SaveChangesAsync();
                        if (row > 0)
                        {
                            model.IsCompleted = true;
                            model.Message = "حساب کاربری شما فعال گردید";
                            return View(model);
                        }

                        model.IsCompleted = false;
                        ModelState.AddModelError("global", "خطا در پاسخگویی");
                        return View(model);
                    }

                    model.IsCompleted = false;
                    model.Message = "کد وارد شده اعتبار ندارد";
                    return View(model);
                }
                catch (Exception e)
                {
                   _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> forgotpass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> forgotpass(ForgotPassViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _accountService.GetUserAsync(model.phonenumber);
                    if (user == null)
                    {
                        model.IsCompleted = false;
                        model.Message = "کاربر وجود ندارد";
                        return View(model);
                    }

                    var code = _otpService.GenerateOtpCode(6);
                    var otpsendshorter = new OtpSendShorter(_otpService, code, user.id, _work);
                    var row = await otpsendshorter.DoProcess();
                    if (row > 0)
                    {
                        //BackgroundJob.Enqueue(() => SendActivationCode(code,user.Phonenumber));
                        return RedirectToAction("VerifyPassword", new {phone = user.Phonenumber});
                    }

                    model.IsCompleted = false;
                    model.Message = "خطا در پاسخگویی";
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VerifyPassword(string? phone)
        {
            
            var verifypass = new VerifypassViewModel()
            {
                phone = phone
            };
            return View(verifypass);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyPassword(VerifypassViewModel? model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var otp = await _otpService.GetOtpCodeAsync(model.code);
                    var user = await _accountService.GetUserAsyncById(otp.userId);
                    if (otp.IsAuthentic)
                    {
                        otp.IsUsed = true;
                        var row = await _work.SaveChangesAsync();
                        if (row > 0)
                        {
                            model.IsCompleted = true;
                            model.Message = "هویت شما با موفقیت تایید شد";
                            return RedirectToAction("ResetPassword",
                                new {id = user.id, Message = model.Message, IsCompleted = model.IsCompleted});
                        }
                    
                        model.IsCompleted = false;
                        ModelState.AddModelError("global", "خطا در پاسخگویی");
                        return View(model);
                    }

                    model.IsCompleted = false;
                    model.Message = "کد وارد شده اعتبار ندارد";
                    return View(model);
                }
                catch (Exception e)
                {
                 _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(int id, string Message, bool IsCompleted)
        {
            var resetpass = new ResetPasswordViewModel()
            {
                id = id,
                Message = Message,
                IsCompleted = IsCompleted
            };
            return View(resetpass);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel? model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _accountService.GetUserAsyncById(model.id);
                    model.Password = _accountService.GenerateHash(model.Password);
                    user.Password = model.Password;
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.IsSuccessful = true;
                        model.Message = "رمز عبور جدید شما با موفقیت تغییر کرد";
                        return View(model);
                    }
                    model.IsCompleted = false;
                    model.Message = "خطا در پایسخگویی";
                    return View(model);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }
    }
    // we are looking over the
    // redis caches management
    // sqlserver caches management
}