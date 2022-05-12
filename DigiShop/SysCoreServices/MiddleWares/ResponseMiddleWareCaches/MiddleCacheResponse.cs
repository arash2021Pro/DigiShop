using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DigiShop.SysCoreServices.MiddleWares.ResponseMiddleWareCaches
{
    public static class MiddleCacheResponse
    {
        public static void UseMiddleWareCacheResponse(this IApplicationBuilder app)
        {
            
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" ,"user-agent"};
                await next();
            });
        }
    }
}