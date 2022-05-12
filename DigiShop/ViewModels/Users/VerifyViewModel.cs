using System.ComponentModel.DataAnnotations;

namespace DigiKalaShop.ViewModels.Users
{
    public class VerifyViewModel
    {
        public string phonenumber { get; set; }
        [Required(ErrorMessage = "کد تایید الزامیست")]
        public string code { get; set; }
    }
}