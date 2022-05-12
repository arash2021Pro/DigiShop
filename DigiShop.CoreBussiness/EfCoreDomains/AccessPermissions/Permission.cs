using System.Collections.Generic;
using DigiShop.CoreBussiness.BasicDomain;

namespace DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions
{
    public class Permission:Core
    {
        public string permission { get; set; }
        public ICollection<RolePermission>RolePermissions { get; set; }
    }
}