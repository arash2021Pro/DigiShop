using System;
using System.Linq;
using System.Security.Claims;

namespace DigiKalaShop.SysCoreServices.AuthenticationServices
{
    public static class AuthenticatedUserService
    {
        public static int GetCurrentUserId(this ClaimsPrincipal user)
        {
            var userId = 0;

            try
            {
                userId = int.Parse(user.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            }
            catch (Exception e)
            {
                
            }
            return userId;
        }
    }
}