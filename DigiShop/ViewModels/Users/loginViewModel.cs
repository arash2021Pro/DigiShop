using System;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace DigiKalaShop.ViewModels.Users
{
    public class loginViewModel
    {
        [Required(ErrorMessage = "شماره همراه الزامیست ")]
        [ValidIranianMobileNumber(ErrorMessage = "موبایل معتبر الزامیست")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "رمز عبور الزامیست ")]
        [MaxLength(20,ErrorMessage = "بیست کارکتر مجازید")]
        public string Password { get; set; }

    }
}