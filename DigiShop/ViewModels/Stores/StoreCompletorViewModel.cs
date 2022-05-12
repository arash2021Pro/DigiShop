using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DigiKalaShop.ViewModels.Stores
{
    public class StoreCompletorViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "ایمیل الزامیست")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیاز است")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "نام فرئشگاه الزامیست ")]
        public string ?StoreName { get; set; }
        [Required(ErrorMessage = "ادرس الزامیست ")]
        public string ?Address { get; set; }
        [Required(ErrorMessage = "تلفن ثابت الزامیست")]
        public bool IsRuleAccepted { get; set; }
        public string ?Telephone { get; set; }
        public IFormFile? file { get; set; }
        [Required(ErrorMessage = "توضیحات الزامیست")]
        public string ?Description { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        
    }
}