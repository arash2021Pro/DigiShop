using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using DigiKalaShop.SysCoreServices.AuthenticationServices;
using DigiKalaShop.ViewModels.OTP;
using DigiKalaShop.ViewModels.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DigiShop.InfraStructure.MailkitServices;
using DigiShop.SysCoreServices.FileHandlers;
using DigiShop.ViewModels.Sellers;
using Hangfire;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace DigiShop.Controllers
{
    public class SellerController:Controller
    {
        private IUnitOfWork _work;
        private IAccountService _accountService;
        private IMapper _mapper;
        private IOtpService _otpService;
        private IMessageService _messageService;
        private IAccessPermissionService _accessPermissionService;
        private IStoreService _storeService;
        private IEmailSendMessage _emailSendMessage;
        private IFileManager _fileManager;
        private IWebHostEnvironment _environment;
        private IDocumentService _documentService;
        public SellerController(IUnitOfWork work, IAccountService accountService, IMapper mapper, IOtpService otpService, IMessageService messageService, IAccessPermissionService accessPermissionService, IStoreService storeService, IEmailSendMessage emailSendMessage, IFileManager fileManager, IWebHostEnvironment environment, IDocumentService documentService)
        {
            _work = work;
            _accountService = accountService;
            _mapper = mapper;
            _otpService = otpService;
            _messageService = messageService;
            _accessPermissionService = accessPermissionService;
            _storeService = storeService;
            _emailSendMessage = emailSendMessage;
            _fileManager = fileManager;
            _environment = environment;
            _documentService = documentService;
        }
        public async Task SendActivationCode(string code,string recptor)
        {
            await _messageService.SendMessageAsync("Digishop", recptor, code);
        }
        public void SendEmailActivationCode(string code,string recptor)
        {
             _emailSendMessage.SendEmail("Digishop", recptor, code);
        }
        [HttpGet]
        public async Task<IActionResult> ActivateSellerPanel(string? Message,bool IsCompleted)
        {
            var ActivatePanel = new ActivatePanelViewModel()
            {
                Message = Message,
                IsCompleted = IsCompleted
            };
            return View(ActivatePanel);
        }
        [HttpPost]
        public async Task<IActionResult> ActivateSellerPanel(ActivatePanelViewModel model)
        {
            switch (model.Method)
            {
                case "mobile":
                    return RedirectToAction("VerifyPhonenumber","Seller");
                case "email":
                    return RedirectToAction("VerifyEmail","Seller");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> VerifyPhonenumber()
        {
           
            if (User.Identity == null) { return null;}
            var Verifyphone = new VerifyPhoneViewModel()
            {
                phonenumber = User.Identity.Name
            };
            return View(Verifyphone);
        }
        [HttpPost]
        public async Task<IActionResult> VerifyPhonenumber(VerifyPhoneViewModel model)
        {
            if (ModelState.IsValid)
            {
               var user = await _accountService.GetUserAsync(model.phonenumber);
                if (user == null)
                {
                    model.IsCompleted = false;
                    model.Message = "کاربر وجود ندارد";
                    return View(model);
                }
               var code = _otpService.GenerateOtpCode(6);
                var otpsendshorter = new OtpSendShorter(_otpService,code,user.id,_work);
                var row = await otpsendshorter.DoProcess();
                if (row > 0)
                {
                    //BackgroundJob.Enqueue(() => SendActivationCode(code,user.Phonenumber));
                    return RedirectToAction("VerifyCode", new {phone = user.Phonenumber});
                }
                model.IsCompleted = false;
                model.Message = "خطا در پاسخگویی";
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VerifyCode(string? phone)
        {
            var verifycode = new VerifyCodeViewModel()
            {
                phone = phone
            };
            return View(verifycode);
        }
        [HttpPost]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var otp = await _otpService.GetOtpCodeAsync(model.code);
                if (otp.IsAuthentic)
                {
                    otp.IsUsed = true;
                    var store = await _storeService.GetStoreAsync(otp.userId);
                    if (store.IsPhonenumberActive)
                    {
                        model.IsCompleted = false;
                        model.Message = "فعال سازی موبایل قبلا انجام شده";
                        return RedirectToAction("ActivateSellerPanel",new {Message = model.Message , IsCompleted = model.IsCompleted});
                    }
                    store.IsPhonenumberActive = true;
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "یک مرحله از فعال سازی حساب شما با موفقیت انجام شد";
                        return RedirectToAction("ActivateSellerPanel",new {Message = model.Message , IsCompleted = model.IsCompleted});
                    }
                    model.IsCompleted = false;
                    ModelState.AddModelError("global","خطا در پاسخگویی");
                    return View(model);
                }
                model.IsCompleted = false;
                ModelState.AddModelError(nameof(model.code),"کد وارد شده اعتبار ندارد");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VerifyEmail()
        {
            var user = await _accountService.GetUserAsync(User.Identity.Name);
            var email = _storeService.GetStoreEmailAsync(user.id);
            var verifyEmail = new VerifyEmailViewModel() {email = email};
            return View(verifyEmail);
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserAsync(User.Identity.Name);
                var email = _storeService.GetStoreEmailAsync(user.id);
                if (email == null)
                {
                    model.IsCompleted = false;
                    model.Message = "کاربر وجود ندارد";
                    return View(model);
                }
                var code = _otpService.GenerateOtpCode(6);
                var otpsendshorter = new OtpSendShorter(_otpService,code,user.id,_work);
                var row = await otpsendshorter.DoProcess();
                if (row > 0)
                {
                   // BackgroundJob.Enqueue(() => SendEmailActivationCode(code,email));
                    return RedirectToAction("VerifyEmailCode", new {email = model.email});
                }
                model.IsCompleted = false;
                model.Message = "خطا در پاسخگویی";
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> VerifyEmailCode(string?email)
        {
            var verifyOtp = new VerifyOtpViewModel()
            {
                email = email
            };
            return View(verifyOtp);
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmailCode(VerifyOtpViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var otp = await _otpService.GetOtpCodeAsync(model.code);
                if (otp.IsAuthentic)
                {
                    otp.IsUsed = true;
                    var store = await _storeService.GetStoreAsync(otp.userId);
                    if (store.IsMailActive)
                    {
                        model.IsCompleted = false;
                        model.Message = "فعال سازی ایمیل قبلا انجام شده";
                        return RedirectToAction("ActivateSellerPanel",new {Message = model.Message , IsCompleted = model.IsCompleted});
                    }
                    store.IsMailActive = true;
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = " فعال سازی حساب شما با موفقیت انجام شد";
                        return RedirectToAction("ActivateSellerPanel",new {Message = model.Message , IsCompleted = model.IsCompleted});
                    }
                    model.IsCompleted = false;
                    ModelState.AddModelError("global","خطا در پاسخگویی");
                    return View(model);
                }
                model.IsCompleted = false;
                ModelState.AddModelError(nameof(model.code),"کد وارد شده اعتبار ندارد");
                return View(model);
            }
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> SendDocument(string? Message,bool IsCompleted)
        {
            if (!String.IsNullOrEmpty(Message))
            {
                var document = new SendDocumentViewModel()
                {
                    Message = Message,
                    IsCompleted = IsCompleted
                };
                return View(document);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendDocument(SendDocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var extention = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 6);
                try
                {
                    var HasUncertain = await _documentService.HasUncertainAsync(User.GetCurrentUserId());
                    if (HasUncertain)
                    {
                        model.Message = "صبر کنین تا مدیر سیستم مدارک قبلی را بازبینی کند";
                        ModelState.AddModelError("global", model.Message);
                        return View(model);
                    }
                    var document = new Document();
                    _mapper.Map(model, document);
                    document.userId = User.GetCurrentUserId();
                    await _fileManager.UploadImageAsync(_environment, "Images", "Document", extention, model.File);
                    await _documentService.InsertDocumentAsync(document);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "مدارک با موفقیت ارسال شد . لطفا تا تایید مدیر صبر کنین ";
                        model.Message = HttpUtility.UrlDecode(model.Message.Replace("", "-"));
                        return RedirectToAction("SendDocument", "Seller",
                            new {Message = model.Message, IsCompleted = model.IsCompleted});
                    }
                    model.IsCompleted = false;
                    model.Message = "خطا در ثبت اطلاعات";
                    ModelState.AddModelError("global", model.Message);
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e.Message, e);
                }
            }
            return View(model);
        }
        
        
    }
}