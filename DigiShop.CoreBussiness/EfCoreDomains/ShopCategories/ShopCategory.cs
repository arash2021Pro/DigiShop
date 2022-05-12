using DigiShop.CoreBussiness.BasicDomain;
using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;

namespace DigiShop.CoreBussiness.EfCoreDomains.ShopCategories
{
    public class ShopCategory:Core
    {
        public int userId { get; set; }
        public Store Store { get; set; }
        public int storecategoryId { get; set; }
        public StoreCategory StoreCategory { get; set; }
        public bool IsActive { get; set; }
        public string Desc { get; set; }
        public string Docserial { get; set; }
    }
}