using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using DigiShop.InfraStructure.MailkitServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigiKalaShop.SysCoreServices.BindService
{
    public static class Binder
    {
        public static void StartBindService(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<KavenegerOptions>(option => configuration.GetSection("Kavenegar:Apikey").Bind(option));
            service.Configure<SmtpOptions>(option => configuration.GetSection("SMTP").Bind(option));
        }
    }
}