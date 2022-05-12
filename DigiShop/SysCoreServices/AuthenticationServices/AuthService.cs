using System;
using System.Linq;
using System.Security.Claims;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DigiKalaShop.SysCoreServices.AuthenticationServices
{
    public static class AuthService
    {
        public static void StartAuthenticationService(this IServiceCollection service)
        {

         service.AddAuthentication(option =>
             {
                 option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                 option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                 option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
             }).AddCookie(option =>
             {
                 option.LoginPath = "/Account/login";
                 option.LogoutPath = "/Account/logout";
                 option.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                 option.SlidingExpiration = true;
                 option.Events = new CookieAuthenticationEvents()
                 {
                     OnValidatePrincipal = async context =>
                     {
                         var userId = int.Parse(context.Principal.Claims.First(u=>u.Type == ClaimTypes.NameIdentifier).Value);
                         var serialnumber = context.Principal.Claims.First(s => s.Type == "Userserial").Value;
                         var IAccountService = context.HttpContext.RequestServices.GetRequiredService<IAccountService>();
                         var user = await IAccountService.GetUserAsyncById(userId);
                         if (user.Userserial != serialnumber)
                         {
                             context.RejectPrincipal();
                         }
                     }
                 };
             });
         
        }
    }
}