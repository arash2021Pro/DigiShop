using System.ComponentModel.DataAnnotations;

namespace DigiKalaShop.ViewModels.Users
{
    public class ForgotPassViewModel
    {
        [Required(ErrorMessage = "موبایل الزامیست")]
        [Phone(ErrorMessage = "موبایل معتبر نیاز است")]
        public string? phonenumber { get; set; }
        public string?Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}