using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.AccessPermissionServices
{
    public class AccessPermissionService:IAccessPermissionService
    {
        public DbSet<Role> _Roles;
        public DbSet<User> _Users;
        public DbSet<Permission>_Permissions;
        public DbSet<RolePermission> _RolePermissions;
        public AccessPermissionService(IUnitOfWork work)
        {
            _Users = work.Set<User>();
            _Roles = work.Set<Role>();
            _Permissions = work.Set<Permission>();
            _RolePermissions = work.Set<RolePermission>();
        }
        public async Task AddRoleASync(Role role) => await _Roles.AddAsync(role);
        public int SearchRoleAsync(string rolename)=> _Roles.FirstOrDefault(r=>r.rolename == rolename).id;
        public async Task UpdateRoleAsync(string phonenumber)
        {
            var user = await _Users.FirstOrDefaultAsync(u => u.Phonenumber == phonenumber);
            user.UserStatus = UserStatus.None;
            var roleId = SearchRoleAsync("seller");
            user.roleId = roleId;
        }
        public int GetStoreRoleAsync() => _Roles.FirstOrDefault(r => r.rolename == "seller")!.id;

        public async Task<bool> IsPermissionExistsAsync(string permission) =>
            await _Permissions.AnyAsync(p => p.permission == permission);

        public async Task AddPermissionAsync(Permission permission) => await _Permissions.AddAsync(permission);

        public async Task<Permission> GetPermissionAsync(int permissionId) =>
            await _Permissions.FirstOrDefaultAsync(p => p.id == permissionId);

        public async Task<bool> IsRoleExistsAsync(string role) => await _Roles.AnyAsync(r => r.rolename == role);
        public async Task<Role> GetRoleAsync(int roleId) => await _Roles.FirstOrDefaultAsync(r => r.id == roleId);

     
        public async Task< List<Permission>> GetPermissionList() => await _Permissions.ToListAsync();

        public async Task<List<Permission>> GetPermissionListAsync(string? searchvalue) => String.IsNullOrEmpty(searchvalue)
            ? await GetPermissionList()
            : await _Permissions.Where(p => p.permission == searchvalue).ToListAsync();

        
        
        public async Task<RolePermission> GetRolePermissionAsync(int id) =>
            await _RolePermissions.FirstOrDefaultAsync(r => r.id == id);

        public async Task<List<Role>> GetRoleListAsync() => await _Roles.ToListAsync();
        

        public async Task<List<Role>> GetRoleListAsync(string? searchvalue) => String.IsNullOrEmpty(searchvalue)
            ? await GetRoleListAsync()
            : await _Roles.Where(r => r.rolename == searchvalue).ToListAsync();
        
    }
}