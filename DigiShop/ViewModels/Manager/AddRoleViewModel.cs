using System.ComponentModel.DataAnnotations;

namespace DigiShop.ViewModels.Manager
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "نقش الزامیست")]
        public string rolename { get; set; }
        public string?Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}