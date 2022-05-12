using DigiShop.AppService.AccessPermissionServices;
using DigiShop.AppService.AccountServices;
using DigiShop.AppService.OtpServices;
using DigiShop.AppService.StoreServices;
using DigiShop.AppService.AccountServices;
using DigiShop.AppService.DocumentServices;
using DigiShop.AppService.OtpServices;
using DigiShop.AppService.SignInlogServices;
using DigiShop.AppService.SiteSettingServices;
using DigiShop.AppService.StoreServices;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DigiShop.StorageService.SqlContext;
using DigiShop.SysCoreServices.PropellantServices.EncriptedServices;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DigiShop.InfraStructure.MailkitServices;
using DigiShop.StorageService.SqlContext;
using DigiShop.SysCoreServices.DatabaseInitializations;
using DigiShop.SysCoreServices.FileHandlers;
using DigiShop.SysCoreServices.PropellantServices.EncriptedServices;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Serilog;
using Serilog.Core;

namespace DigiKalaShop.SysCoreServices.ApplicationServices
{
    public static class AppServices
    {
        public static void StartAppServices(this IServiceCollection service)
        {
            service.AddSingleton<IUnitOfWork, ApplicationContext>();
            service.AddSingleton<IAccountService, AccountService>();
            service.AddSingleton<IOtpService, OtpService>();
            service.AddSingleton<ICodeGenerator,CodeGenerator>();
            service.AddSingleton<IHashGenerator, HashGenerator>();
            service.AddSingleton<IMessageService, MessageService>();
            service.AddSingleton<IMapper,Mapper>();
            service.AddSingleton<IAccessPermissionService, AccessPermissionService>();
            service.AddSingleton<IStoreService, StoreService>();
            service.AddSingleton<IEmailSendMessage,MailkitService>();
            service.AddSingleton<ISetSettings, SiteSettingService>();
            service.AddSingleton<IDatabaseInitializer, InitializationService>();
            service.AddSingleton<ISignInLog, SignInLogService>();
            service.AddSingleton<IFileManager, FileManager>();
            service.AddSingleton<IDocumentService, DocumentService>();
            // service.AddScoped<ILogger, Logger>();
        }
    }
}