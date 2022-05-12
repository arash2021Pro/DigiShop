using DigiShop.CoreBussiness.EfCoreDomains.Users;

namespace DigiShop.CoreBussiness.EfCoreDomains.Stores
{
    public class Store
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Mail { get; set; }
        public string ?StoreName { get; set; }
        public string ?Address { get; set; }
        public string ?Telephone { get; set; }
        public string ?Logo { get; set; }
        public string ?Description { get; set; }
        public StoreStatus StoreStatus { get; set; }
        public bool IsPhonenumberActive { get; set; }
        public bool IsMailActive { get; set; }
        public bool IsRuleAccepted { get; set; }
    }
}