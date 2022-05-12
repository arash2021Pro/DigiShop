using System;
using System.IO;
using System.Threading.Tasks;
using DigiKalaShop.SysCoreServices.AuthenticationServices;
using DigiKalaShop.ViewModels.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DigiShop.StorageService.Migrations;
using DigiShop.SysCoreServices.FileHandlers;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace DigiShop.Controllers
{
    public class StoreController:Controller
    { 
        private IUnitOfWork _work;
        private IAccountService _accountService;
        private IMapper _mapper;
        private IOtpService _otpService;
        private IMessageService _messageService;
        private IAccessPermissionService _accessPermissionService;
        private IStoreService _storeService;
        private IWebHostEnvironment _environment;
        private IFileManager _fileManager;
        public StoreController(IUnitOfWork work, IAccountService accountService, IMapper mapper, IOtpService otpService, IMessageService messageService, IAccessPermissionService accessPermissionService, IStoreService storeService, IWebHostEnvironment environment, IFileManager fileManager)
        {
            _work = work;
            _accountService = accountService;
            _mapper = mapper;
            _otpService = otpService;
            _messageService = messageService;
            _accessPermissionService = accessPermissionService;
            _storeService = storeService;
            _environment = environment;
            _fileManager = fileManager;
        }
        public async Task SendActivationCode(string code,string recptor)
        {
            await _messageService.SendMessageAsync("Digishop", recptor, code);
        }
        [HttpGet]
        public async Task<IActionResult> SignupStore()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignupStore(SignupStoreViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var IsemailExists = await _storeService.IsEmailExistsAsync(model.Mail);
                if (IsemailExists)
                {
                    ModelState.AddModelError(nameof(model.Mail),"ایمیل وجود دارد ...");
                    return View(model);
                }
                var userId = 0;
                var result = await _accountService.IsPhonenumberExistsAsync(model.Phonenumber);
                if (result)
                {
                   await _accessPermissionService.UpdateRoleAsync(model.Phonenumber);
                   userId = _accountService.GetUserIdAsync(model.Phonenumber);
                   await _work.SaveChangesAsync();
                }
                else
                {
                    var user = new User()
                    {
                        Phonenumber = model.Phonenumber,
                        roleId = _accessPermissionService.SearchRoleAsync(model.fixedrole),
                        NationalCode = null,
                        Password = _accountService.GenerateHash(model.Password),
                        UserStatus = UserStatus.None,
                        IsRulesAccepted = model.IsRuleAccepted
                    };
                    await _accountService.SignupUserAsync(user);
                    await _work.SaveChangesAsync();
                    userId = user.id;
                }
                var store = new Store()
                {
                    Address = "null", Logo = "null", Mail = model.Mail, Description = "null", StoreName = "null",
                    StoreStatus = StoreStatus.None, Telephone = "null", IsMailActive = false, IsPhonenumberActive = false,
                    UserId = userId
                };
                await _storeService.AddNewStoreAsync(store);
                var row = await _work.SaveChangesAsync();
                if (row > 0)
                {
                    model.IsCompleted = true;
                    model.Message = "کاربر محترم فروشگاه شما ثبت گردید . لطفا برای کامل کردن اطلاعات فروشگاه خود اقدام فرمایید";
                    return View(model);
                }
                model.IsCompleted = false;
                model.Message = "خطا در پاسخگویی";
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> StoreCompletor()
        {
            var store = await _storeService.GetStoreAsync(User.GetCurrentUserId());
            var datastore = new StoreCompletorViewModel() {id =User.GetCurrentUserId(), Address = store.Address, Description = store.Address, Mail = store.Mail, Telephone = store.Telephone, StoreName = store.StoreName,IsRuleAccepted = store.IsRuleAccepted};
            return View(datastore);
        }
        [HttpPost]
        public async Task<IActionResult> StoreCompletor(StoreCompletorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var store = await _storeService.GetStoreAsync(User.GetCurrentUserId());
                    store.Address = model.Address;
                    store.Description = model.Description;
                    store.Logo = null;
                    store.Mail = model.Mail;
                    store.Telephone = model.Telephone;
                    store.StoreName = model.StoreName;
                    store.IsRuleAccepted = model.IsRuleAccepted;
                    if (Path.GetExtension(model.file.FileName) == ".JPG" || Path.GetExtension(model.file.FileName) == ".jpg")
                    {
                        await _fileManager.UploadImageAsync(_environment, "Images", "Document", model.file, store.UserId);
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(model.file),"فقط فایل با پسوند jpg قبول میشود");
                        return View(model);
                    }
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "اطلاعات فروشگاه شما با موفقیت ثبت شد"; 
                        return RedirectToAction("DashBoard", "Admin",new {Message = model.Message,IsCompleted = model.IsCompleted});
                    }
                    model.IsCompleted = false;
                    model.Message = "خطا در پاسخگویی";
                    return View(model);
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e.Message,e);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Download()
        {
            try
            {
                var data = await _fileManager.DownloadImageAsync(_environment,"Images","Document",User.GetCurrentUserId());
                return File(data, "Image/jpg");
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message,e);
            }
            return BadRequest();
        }

        public async Task<IActionResult> print()
        {
            return View();
        }
    }
}