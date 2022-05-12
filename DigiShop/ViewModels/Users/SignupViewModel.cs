using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace DigiKalaShop.ViewModels.Users
{
    public class SignupViewModel
    {
        [ValidIranianMobileNumber(ErrorMessage = "شماره همراه صحیح نیست")]
        [MinLength(11)]
        [Required(ErrorMessage = "شماره همراه الزامیست")]
        public string Phonenumber { get; set; }
        [MaxLength(20,ErrorMessage = "مجاز به بیشتر از بیست کارکتر نیستید")]
        [Required(ErrorMessage = "کلمه عبور الزامیست")]
        public string Password { get; set; }
        [ValidIranianNationalCode(ErrorMessage = "کد ملی صحیح نیست")]
    
        public string NationalCode { get; set; }
        [Compare("Password",ErrorMessage = "کلمه ی عبور مطابقت ندارد")]
        [Required(ErrorMessage = "تایید کلمه ی عبور الزامیست")]
        public string ConfirmedPassword { get; set; }
        public bool IsRulesAccepted { get; set; }
        public string role { get; set; }
        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}