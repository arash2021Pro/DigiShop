using System.Threading.Tasks;
using DigiKalaShop.SysCoreServices.AuthenticationServices;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.AspNetCore.Http;

namespace DigiKalaShop.ViewModels.OTP
{
    public class SignInLogShorter
    {
        private IUnitOfWork _work;
        private ISignInLog _signInLog;
        private HttpContext _httpContext;
        public SignInLogShorter(IUnitOfWork work, ISignInLog signInLog, HttpContext httpContext)
        {
            _work = work;
            _signInLog = signInLog;
            _httpContext = httpContext;
        }
        public async Task HandleLogAsync()
        {
            var device = new DeviceShorter(_httpContext);
            var SignInlog = new SignInLog();
            SignInlog.Browser = _httpContext.Request.Headers["user-agent"].ToString();
            SignInlog.Username = _httpContext.User.Identity.Name;
            SignInlog.userId = _httpContext.User.GetCurrentUserId();
            SignInlog.DeviceName = device.devicename;
            SignInlog.UrlAction = _httpContext.Request.RouteValues["controller"] + "/" + _httpContext.Request.RouteValues["action"];
            await _signInLog.AddNewLogAsync(SignInlog);
            await _work.SaveChangesAsync();
        }
    }
}