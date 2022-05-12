using System.ComponentModel.DataAnnotations;

namespace DigiShop.ViewModels.Manager
{
    public class ModifyPermissionViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "دسترسی الزامیست")]
        public string Permission { get; set; }
        public string?Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}