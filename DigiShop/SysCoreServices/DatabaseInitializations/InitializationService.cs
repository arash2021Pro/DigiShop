using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.SysCoreServices.DatabaseInitializations
{
    public class InitializationService:IDatabaseInitializer
    {
        private IUnitOfWork _work;
        public InitializationService(IUnitOfWork work)
        {
            _work = work;
        }
        public async Task SeedData()
        {
            var settings = _work.Set<SiteSetting>();
            if (!await settings.AnyAsync())
            {
                var siteSetting = new SiteSetting()
                {
                    SiteKey = null,
                    SiteName = "DigiShop",
                    EmailAddress = "arashmadadi293@gmail.com",
                    EmailPassword = "money20202001love",
                    SiteDescription = "This App is for resume",
                    SmsApi = null,
                    SmsSender = null,
                };
                await settings.AddAsync(siteSetting);
                await _work.SaveChangesAsync();
            }
        }
    }
}