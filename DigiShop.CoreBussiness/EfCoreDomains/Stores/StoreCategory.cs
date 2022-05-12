using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigiShop.CoreBussiness.BasicDomain;

namespace DigiShop.CoreBussiness.EfCoreDomains.StoreCategories
{
    public class StoreCategory
    {
        
        public int id { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("Parent")]
        public int?ParentId { get; set; }
        public string? icon { get; set; }
        public virtual StoreCategory Parent { get; set; }
    }
}