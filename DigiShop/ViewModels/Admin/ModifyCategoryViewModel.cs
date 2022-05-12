using System.ComponentModel.DataAnnotations;

namespace DigiShop.ViewModels.Admin
{
    public class ModifyCategoryViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "نام دسته الزامیست")]
        public string CategoryName { get; set; }
        public string? icon { get; set; }
        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}