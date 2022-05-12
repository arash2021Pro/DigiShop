using System.Collections.Generic;
using DigiShop.CoreBussiness.BasicDomain;
using DigiShop.CoreBussiness.EfCoreDomains.Users;

namespace DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions
{
    public class Role:Core
    {
        public string rolename { get; set; }
        public  ICollection<RolePermission>RolePermissions { get; set; }
        public virtual ICollection<User>Users { get; set; }
    }
}