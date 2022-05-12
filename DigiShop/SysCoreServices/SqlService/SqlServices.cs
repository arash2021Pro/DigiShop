using DigiShop.StorageService.SqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigiShop.SysCoreServices.SqlService
{
    public static class SqlServices
    {
        public static void StartSqlService(this IServiceCollection service, IConfiguration configuration)
        {
            var StorageUrl = configuration.GetConnectionString("DefaultConnection");
            service.AddDbContextPool<ApplicationContext>(option => option.UseSqlServer(StorageUrl));
        }
    }
}