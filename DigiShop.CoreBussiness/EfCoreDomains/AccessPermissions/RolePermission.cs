using DigiShop.CoreBussiness.BasicDomain;

namespace DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions
{
    public class RolePermission:Core
    {
        public int roleId { get; set; }
        public Role Role { get; set; }
        public int permissionId { get; set; }
        public Permission Permission { get; set; }
    }
}