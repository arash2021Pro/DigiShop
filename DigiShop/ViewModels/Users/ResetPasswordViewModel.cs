using System.ComponentModel.DataAnnotations;

namespace DigiKalaShop.ViewModels.Users
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "رمز عبور جدید الزامیست")]
        public string Password { get; set; }
        public int id { get; set; }
        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSuccessful { get; set; }
    }
}