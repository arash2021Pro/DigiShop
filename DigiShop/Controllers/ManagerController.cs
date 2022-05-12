using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiKalaShop.SysCoreServices.PropellantServices.CoreAttributes;
using DigiKalaShop.ViewModels.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.ViewModels.Manager;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DigiShop.Controllers
{
    [Authorize]
    public class ManagerController:Controller
    {
        private IUnitOfWork _work;
        private IMapper _mapper;
        private ISetSettings _settings;
        private IAccessPermissionService _accessPermissionService;
        private readonly ILogger<ManagerController> _logger;
        public ManagerController(IUnitOfWork work, IMapper mapper, ISetSettings settings, IAccessPermissionService accessPermissionService,ILogger<ManagerController> logger)
        {
            _work = work;
            _mapper = mapper;
            _settings = settings;
            _logger = logger;
            _accessPermissionService = accessPermissionService;
        }
        
        [HttpGet]
        public async Task<IActionResult> AddSiteSetting(string ?Message,bool? IsCompleted)
        {
            var setting = new SettingViewModel()
            {
                Message = Message, IsCompleted = IsCompleted
            };
            return View(setting);
        }
        [HttpPost]
        public async Task<IActionResult> AddSiteSetting(SettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var setting = new SiteSetting();
                    _mapper.Map(model, setting);
                    await _settings.AddSettingAsync(setting);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "تنظیمات اضافه شد";
                        return RedirectToAction("AddSiteSetting",new {Message =model.Message,IsCompleted = model.IsCompleted });
                    }
                    model.IsCompleted = false;
                    model.Message = "خطا در پاسخگویی";
                    return RedirectToAction("AddSiteSetting",new {Message =model.Message,IsCompleted = model.IsCompleted });
                }
                catch (Exception e)
                {
                   _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ModifySetting(string ?Message,bool?IsCompleted, int id =1)
        {
            var setting = await _settings.GetSiteSettingAsync(id);
            var data = setting.Adapt<ModifySettingViewModel>();
            data.Message = Message;
            data.IsCompleted = IsCompleted;
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> ModifySetting(ModifySettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var setting = await _settings.GetSiteSettingAsync(1);
                    _mapper.Map(model, setting);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "تغییرات اعمال شد";
                        return RedirectToAction("ModifySetting",new {Message =model.Message,IsCompleted = model.IsCompleted });
                    }
                    model.IsCompleted = false;
                    model.Message = "خطا در پاسخگویی";
                    return RedirectToAction("ModifySetting",new {Message =model.Message,IsCompleted = model.IsCompleted });
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message,e);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddPermission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPermission(AddPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _accessPermissionService.IsPermissionExistsAsync(model.Permission);
                    if (result)
                    {
                        ModelState.AddModelError(nameof(model.Permission),"این دسترسی در سیستم وجود دارد");
                        return View(model);
                    }
                    var permission = new Permission();
                    permission.permission = model.Permission;
                    await _accessPermissionService.AddPermissionAsync(permission);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "با موفقیت اضافه شد";
                        return View(model);
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
        public async Task<IActionResult> ModifyPermission(int id)
        {
            var permission = await _accessPermissionService.GetPermissionAsync(id);
            var data = new ModifyPermissionViewModel()
            {
                Permission = permission.permission,
                id = permission.id
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> ModifyPermission(ModifyPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var permission = await _accessPermissionService.GetPermissionAsync(model.id);
                    permission.permission = model.Permission;
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "با موفقیت تغییر کرد";
                        return View(model);
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
        public async Task<IActionResult> AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _accessPermissionService.IsRoleExistsAsync(model.rolename);
                    if (result)
                    {
                        ModelState.AddModelError(nameof(model.rolename),"این نقش در سیستم وجود دارد");
                        return View(model);
                    }
                    var role = new Role();
                    role.rolename = model.rolename;
                    await _accessPermissionService.AddRoleASync(role);
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "با موفقیت اضافه شد";
                        return View(model);
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
        public async Task<IActionResult> ModifyRole(int? id)
        {
            var role = await _accessPermissionService.GetRoleAsync(id.Value);
            if (role == null)
            {
                return RedirectToAction("ModifyRole", new {id = 0});
            }
            var data = new ModifyRoleViewModel()
            {
                id = role.id,
                rolename = role.rolename
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyRole(ModifyRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _accessPermissionService.GetRoleAsync(model.id);
                    role.rolename = model.rolename;
                    var row = await _work.SaveChangesAsync();
                    if (row > 0)
                    {
                        model.IsCompleted = true;
                        model.Message = "با موفقیت اضافه شد";
                        return View(model);
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
        public async Task<IActionResult> ManageRoleAccess(string?searchvalue)
        {
            try
            {
                var Permissions = String.IsNullOrEmpty(searchvalue) ? await _accessPermissionService.GetPermissionList():  await _accessPermissionService.GetPermissionListAsync(searchvalue);
                return View(Permissions);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
            }
            return View();
        }

        public async Task<IActionResult> ManageRole(string?searchvalue)
        {
            try
            {
                var roles = String.IsNullOrEmpty(searchvalue) ? await _accessPermissionService.GetRoleListAsync():  await _accessPermissionService.GetRoleListAsync(searchvalue);
                return View(roles);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> BlockPermission(int id)
        {
            try
            {
                var Permission = await _accessPermissionService.GetPermissionAsync(id); 
                Permission.IsDeleted = true;
                var row =  await _work.SaveChangesAsync();
                if(row > 0){return RedirectToAction("ManageRoleAccess","Manager");}
                return BadRequest("خطا در شبکه");
            }
            catch (Exception e)
            {
               _logger.LogError(e.Message,e);
            }
            
            return BadRequest();
        }

    }
}