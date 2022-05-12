using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.SiteSettingServices
{
    public class SiteSettingService:ISetSettings
    {
        private DbSet<SiteSetting> _siteSettings;
        public SiteSettingService(IUnitOfWork work)
        {
            _siteSettings = work.Set<SiteSetting>();
        }

        public async Task AddSettingAsync(SiteSetting siteSetting) => await _siteSettings.AddAsync(siteSetting);

        public async Task<SiteSetting> GetSiteSettingAsync(int id) =>
            await _siteSettings.FirstOrDefaultAsync(s => s.id == id);


    }
}