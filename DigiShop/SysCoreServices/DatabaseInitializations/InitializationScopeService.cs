using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DigiShop.SysCoreServices.DatabaseInitializations
{
    public static class InitializationScopeService
    {
        public static void StartScopeService(this IApplicationBuilder app)
        {
             var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
             using (var scope=scopeFactory.CreateScope())
             {
                 var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
                 databaseInitializer.SeedData();
             }
        }
    }
}