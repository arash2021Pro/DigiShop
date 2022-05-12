using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiKalaShop.SysCoreServices.ApplicationServices;
using DigiKalaShop.SysCoreServices.AuthenticationServices;
using DigiKalaShop.SysCoreServices.BindService;
using DigiKalaShop.SysCoreServices.ElmahCoreServices;
using DigiKalaShop.SysCoreServices.HangfireServices;
using DigiShop.SysCoreServices.CaptchaService;
using DigiShop.SysCoreServices.DatabaseInitializations;
using DigiShop.SysCoreServices.MiddleWares.ResponseMiddleWareCaches;
using DigiShop.SysCoreServices.SqlService;
using ElmahCore.Mvc;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DigiShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.StartAppServices();
            services.StartSqlService(Configuration);
            services.StartAuthenticationService();
            services.StartHangfireService(Configuration);
            services.AddElmahService(Configuration);
            services.StartBindService(Configuration);
            services.StartCaptchaService();
            services.AddResponseCaching(option =>
            {
                option.MaximumBodySize = 1024;
                option.UseCaseSensitivePaths = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           // app.StartScopeService();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseAuthentication();
            app.UseResponseCaching(); 
            app.UseMiddleWareCacheResponse();
            app.UseAuthorization();
            app.UseElmah();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHangfireDashboard();
            });
        }
    }
}