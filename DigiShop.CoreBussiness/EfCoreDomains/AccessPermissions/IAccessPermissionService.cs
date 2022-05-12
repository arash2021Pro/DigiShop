using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions
{
    public interface IAccessPermissionService
    {
        Task AddRoleASync(Role role);
        int SearchRoleAsync(string rolename);
        Task UpdateRoleAsync(string phonenumber);
        public int GetStoreRoleAsync();
        Task<bool> IsPermissionExistsAsync(string permission);
        Task AddPermissionAsync(Permission permission);
        Task<Permission> GetPermissionAsync(int permissionId);
        Task<bool> IsRoleExistsAsync(string role);
        Task<Role> GetRoleAsync(int roleId);
        Task  <List<Permission>> GetPermissionListAsync(string?searchvalue);
        Task <List<Permission>> GetPermissionList();
        Task<RolePermission> GetRolePermissionAsync(int id);
        Task<List<Role>> GetRoleListAsync(string? searchvalue);
        Task<List<Role>> GetRoleListAsync();

    }
}