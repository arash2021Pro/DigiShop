using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace DigiKalaShop.ViewModels.Stores
{
    public class SignupStoreViewModel
    {
        [EmailAddress(ErrorMessage = "ایمیل معتبر الزامیست")]
        [Required(ErrorMessage = "ایمیل الزامیست")]
        public string Mail { get; set; }
        [ValidIranianMobileNumber(ErrorMessage = "تلفن معتبر الزامیست")]
        [Required(ErrorMessage = "تلفن الزامیست")]
        [MaxLength(11,ErrorMessage = "یازده کارکتر مجاز هستید")]
        public string Phonenumber { get; set; }
        [DataType(DataType.Password,ErrorMessage = "کلمه عبورمعتبر الزامیست")]
        [Required(ErrorMessage = "کلمه عبور الزامیست")]
        [MinLength(4,ErrorMessage = "کمتر از چهار کارکتر مجاز نیستید")]
        [MaxLength(8,ErrorMessage = "بیشتر از عشت کارکتر مجاز نیستید")]
        public string Password { get; set; }
        public bool IsRuleAccepted { get; set; }
        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
        public string fixedrole { get; set; }
    }
}