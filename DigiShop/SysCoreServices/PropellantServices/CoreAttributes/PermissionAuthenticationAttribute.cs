using System.Security.Claims;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DigiKalaShop.SysCoreServices.PropellantServices.CoreAttributes
{
    public class PermissionAuthenticationAttribute:AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        int _permissionId;
        public PermissionAuthenticationAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = context.HttpContext.User.Identity.Name;
                var AccountService = context.HttpContext.RequestServices.GetRequiredService<IAccountService>();
                var roleId = AccountService.GetUserRole(username);
                if (!await AccountService.HasPermissionAsync(_permissionId, roleId))
                {
                    context.Result = new RedirectResult("/Account/login/");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/login");
            }
        }
    }
}