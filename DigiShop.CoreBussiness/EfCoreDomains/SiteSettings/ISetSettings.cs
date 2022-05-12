using System.Threading.Tasks;

namespace DigiShop.CoreBussiness.EfCoreDomains.SiteSettings
{
    public interface ISetSettings
    {
        Task AddSettingAsync(SiteSetting siteSetting);
        Task<SiteSetting> GetSiteSettingAsync(int id);
    }
}