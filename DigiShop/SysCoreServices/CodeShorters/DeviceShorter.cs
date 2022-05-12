using System.Net;
using Microsoft.AspNetCore.Http;

namespace DigiKalaShop.ViewModels.OTP
{
    public class DeviceShorter
    {
        public DeviceShorter(HttpContext context)
        {
            devicename = Dns.GetHostEntry(context.Connection.RemoteIpAddress).HostName.ToLower().Substring(0,7);
        }
        public string devicename { get; set; }
    }
}