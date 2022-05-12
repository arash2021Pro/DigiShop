using System;
using System.Threading.Tasks;
using System.Web;
using DigiKalaShop.SysCoreServices.PropellantServices.CoreAttributes;
using DigiKalaShop.ViewModels.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.StorageService.Migrations;
using DigiShop.StorageService.SqlContext;
using DigiShop.SysCoreServices.FileHandlers;
using DigiShop.ViewModels.Admin;
using MailKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StoreCategory = DigiShop.CoreBussiness.EfCoreDomains.StoreCategories.StoreCategory;

namespace DigiShop.Controllers
{
    public class AdminController:Controller
    {
        public IUnitOfWork _work;
        public ISignInLog _signInLog;
        private readonly ILogger<AdminController> _logger;
        private IStoreService _storeService;
        private IAccountService _accountService;
        private IDocumentService _documentService;
        private IFileManager _fileManager;
        private IWebHostEnvironment _environment;
        public AdminController(IUnitOfWork work, ISignInLog signInLog,ILogger<AdminController> logger, IStoreService storeService, IAccountService accountService, IDocumentService documentService, IFileManager fileManager, IWebHostEnvironment environment)
        {
            _work = work;
            _signInLog = signInLog;
            _logger = logger;
            _storeService = storeService;
            _accountService = accountService;
            _documentService = documentService;
            _fileManager = fileManager;
            _environment = environment;
        }
        [HttpGet]
        [PermissionAuthentication(1)]
        public async Task<IActionResult> DashBoard(string? Message,bool IsCompleted)
        {
            try
            {
                if (!String.IsNullOrEmpty(Message))
                {
                    var notify = new NotifiyViewModel()
                    {
                        Message = Message, IsCompleted = true
                    };
                    return View(notify);
                }
                var log = new SignInLogShorter(_work, _signInLog, HttpContext);
                await log.HandleLogAsync();
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> ShowCategoryHead(string? searchvalue)
        {
            try
            {
                var MainCategories = await _storeService.GetCategoryListAsync(searchvalue);
                return View(MainCategories);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
            }
            return BadRequest();
   
        }
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _storeService.IsCategoryExistsAsync(model.CategoryName);
                    if (result)
                    {
                        ModelState.AddModelError(nameof(model.CategoryName),"دسته وجود دارد");
                        return View(model);
                    }
                    var storecategory = new StoreCategory();
                    storecategory.ParentId = null;
                    storecategory.icon = model.icon;
                    storecategory.CategoryName = model.CategoryName;
                    await _storeService.InsertCategoryAsync(storecategory);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "دسته با موفقیت صبت شد";
                        return RedirectToAction("ShowCategoryHead","Admin");
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

        [HttpGet]
        public async Task<IActionResult> AddChild()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddChild(AddChildViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var subcategory = new StoreCategory()
                    {
                        icon = null,
                        CategoryName = model.child,
                        ParentId = model.id
                    };
                    await _storeService.InsertCategoryAsync(subcategory);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "دسته با موفقیت صبت شد";
                        return RedirectToAction("SubCategory","Admin");
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


        [HttpGet]
        public async Task<IActionResult> ModifyCategory(int id)
        {
            try
            {
                var category = await _storeService.GetStoreCategoryAsync(id);
                var data = new ModifyCategoryViewModel()
                {
                    id = category.id, icon = category.icon, CategoryName = category.CategoryName
                };
                return View(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
            }
            return BadRequest();

        }
        
        [HttpPost]
        public async Task<IActionResult> ModifyCategory(ModifyCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var category = await _storeService.GetStoreCategoryAsync(model.id);
                    category.icon = model.icon;
                    category.CategoryName = model.CategoryName;
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        return RedirectToAction("ShowCategoryHead", "Admin");
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

        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _storeService.DeleteStoreCategoryAsync(id);
                var row = await _work.SaveChangesAsync();
                if (row > 0)
                    return RedirectToAction("ShowCategoryHead", "Admin");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
            }
            return BadRequest("server not responding");
        }

        [HttpGet]
        public async Task<IActionResult> SellerList()
        {
            var sellers = await _accountService.GetSellersListAsync();
            return View(sellers);
        }
        [HttpGet]
        public async Task<IActionResult> SubCategory()
        {
            var categories = await _storeService.GetSubCategoryListAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> DocList(int id)
        {
            var docs = await _documentService.DocumentListAsync(id);
            return View(docs);
        }
        [HttpGet]
        public async Task<IActionResult> DownloadImage(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            var data = await _fileManager.DownloadImageAsync(_environment, "Images", "Document", document.filename);
            return File(data, "Image/png");
        }
        [HttpGet]
        public async Task<IActionResult> DocDetails(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> DocDetails(int id , string action)
        {
            switch (action)
            {
                case "reject":
                    return await RejectDoc(id);
                default:
                    return await ConfirmDoc(id);
            }
        }
        private async Task<IActionResult> ConfirmDoc(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            document.AuthStatus = AuthStatus.Accepted;
            var store = await _storeService.GetStoreAsync(document.userId);
            store.StoreStatus = StoreStatus.Confirmed;
            var row = await _work.SaveChangesAsync();
            if (row > 0) { return RedirectToAction("DocList",new {id =document.userId}); }
            return RedirectToAction("DocDetails", new { id });
        }
        private async Task<IActionResult> RejectDoc(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            document.AuthStatus = AuthStatus.Rejected;
            var store = await _storeService.GetStoreAsync(document.userId);
            store.StoreStatus = StoreStatus.Rejected;
            var row = await _work.SaveChangesAsync();
            if(row > 0){return RedirectToAction("DocList",new {id=document.userId});}
            return RedirectToAction("DocDetails", new { id });
        }
            
        [HttpGet]
        public async Task<IActionResult> StoreList()
        {
            var stores = await _storeService.GetStoreListAsync();
            return View(stores);
        }


    }
}