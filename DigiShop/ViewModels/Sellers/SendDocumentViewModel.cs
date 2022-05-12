using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DigiKalaShop.ViewModels.Stores
{
    public class SendDocumentViewModel
    {
        //[ValidIranianNationalCode(ErrorMessage = "کد ملی صحیح وارد کنید")]
        public string? NationalCode { get; set; }
        public string? Address { get; set; }
        public string? Homephone { get; set; }
        public IFormFile File { get; set; }
     ///   [CreditCard(ErrorMessage = "شماره کارت صحیح وارد کنید")]
        public string? CardNumber { get; set; }
        public string ?BankName { get; set; }
        public string? AccountOwner { get; set; }
     //   [ValidIranShebaNumber(ErrorMessage = "کد شبای صحیح وارد کنید")]
        public string ?ShabaCode { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
    
    }
}