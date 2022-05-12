using System.ComponentModel.DataAnnotations;

namespace DigiShop.ViewModels.Admin
{
    public class AddChildViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "اضافه کردن زیر دسته الزامیست")]
        public string child { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}