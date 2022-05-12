using DNTCaptcha.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DigiShop.SysCoreServices.CaptchaService
{
    public static class CaptchaServices
    {
        public static void StartCaptchaService(this IServiceCollection services )
        {
            services.AddDNTCaptcha(options =>
            {
                // options.UseSessionStorageProvider() // -> It doesn't rely on the server or client's times. Also it's the safest one.
                // options.UseMemoryCacheStorageProvider() // -> It relies on the server's times. It's safer than the CookieStorageProvider.
                options.UseCookieStorageProvider(SameSiteMode.Strict) // -> It relies on the server and client's times. It's ideal for scalability, because it doesn't save anything in the server's memory.
                    // .UseDistributedCacheStorageProvider() // --> It's ideal for scalability using `services.AddStackExchangeRedisCache()` for instance.
                    // .UseDistributedSerializationProvider()

                    // Don't set this line (remove it) to use the installed system's fonts (FontName = "Tahoma").
                    // Or if you want to use a custom font, make sure that font is present in the wwwroot/fonts folder and also use a good and complete font!
                    // .UseCustomFont(Path.Combine(_en.WebRootPath, "fonts", "IRANSans(FaNum)_Bold.ttf")) // This is optional.
                    .AbsoluteExpiration(minutes: 7)
                    .ShowThousandsSeparators(false)
                    .WithNoise(pixelsDensity: 25, linesCount: 3)
                    .WithEncryptionKey("This is my secure key!")
                    .InputNames(// This is optional. Change it if you don't like the default names.
                        new DNTCaptchaComponent
                        {
                            CaptchaHiddenInputName = "DNTCaptchaText",
                            CaptchaHiddenTokenName = "DNTCaptchaToken",
                            CaptchaInputName = "DNTCaptchaInputText"
                        })
                    .Identifier("dntCaptcha")// This is optional. Change it if you don't like its default name.
                    ;
            });
        }
    }
}