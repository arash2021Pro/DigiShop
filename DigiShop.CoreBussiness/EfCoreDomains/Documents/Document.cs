using DigiShop.CoreBussiness.BasicDomain;
using DigiShop.CoreBussiness.EfCoreDomains.Users;

namespace DigiShop.CoreBussiness.EfCoreDomains.Documents
{
    public class Document:Core
    {
        public string? NationalCode { get; set; }
        public string? Address { get; set; }
        public string? Homephone { get; set; }
        public AuthStatus AuthStatus { get; set; }
        public string filename { get; set; }
        public string? CardNumber { get; set; }
        public string ?BankName { get; set; }
        public string? AccountOwner { get; set; }
        public string ?ShabaCode { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}