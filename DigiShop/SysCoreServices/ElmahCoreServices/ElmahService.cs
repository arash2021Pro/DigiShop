using System.IO;
using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigiKalaShop.SysCoreServices.ElmahCoreServices
{
    public static class ElmahService
    {
        public static void AddElmahService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.Path = "/Elmah";
                // options.OnPermissionCheck = context => context.User.Identity.IsAuthenticated && context.User.IsInRole("Admin");
                //options.LogPath = @"d:\errors";
                options.ConnectionString = configuration.GetConnectionString("elmah");
                options.Filters.Add(new NotFoundFilter());
            });
        }
        public class NotFoundFilter:ElmahCore.IErrorFilter
        {
            public void OnErrorModuleFiltering(object sender, ExceptionFilterEventArgs args)
            {
                if (args.Exception.GetBaseException() is FileNotFoundException)
                {
                    args.Dismiss();
                }
            
                if(args.Context is HttpContext httpContext)
                    if (httpContext.Response.StatusCode == 404)
                        args.Dismiss();
            }
        }
        
    }
}