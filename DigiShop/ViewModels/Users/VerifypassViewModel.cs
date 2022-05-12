using System.ComponentModel.DataAnnotations;

namespace DigiKalaShop.ViewModels.Users
{
    public class VerifypassViewModel
    {
        [Required(ErrorMessage = "کد تایید الزامیست")]
        public string code { get; set; }
        public string? phone { get; set; }
        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}