using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.AccountServices
{
    public class AccountService : IAccountService
    {
        private DbSet<User> _users;
        private DbSet<RolePermission> _rolePermissions;
        private DbSet<Role> _roles;

        public AccountService(IUnitOfWork work)
        {
            _roles = work.Set<Role>();
            _users = work.Set<User>();
            _rolePermissions = work.Set<RolePermission>();
        }

        public string GenerateHash(string password)
        {
            if (String.IsNullOrEmpty(password))
                return "";
            using (var sha = new SHA512Managed())
            {
                var bytes = Encoding.ASCII.GetBytes(password);
                var encripted = sha.ComputeHash(bytes);
                return Encoding.ASCII.GetString(encripted);
            }
        }

        public async Task SignupUserAsync(User user)
        {
            user.Password = GenerateHash(user.Password);
            await _users.AddAsync(user);
        }

        public async Task<User> LoginUserAsync(string phonenumber, string password)
        {
            var encripted = GenerateHash(password);
            return await _users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Phonenumber == phonenumber && u.Password == encripted);
        }

        public async Task<bool> IsPhonenumberExistsAsync(string phonenumber) =>
            await _users.AnyAsync(user => user.Phonenumber.Equals(phonenumber));

        public async Task<User> GetUserAsync(string phonenumber) =>
            await _users.SingleOrDefaultAsync(u => u.Phonenumber == phonenumber);

        public async Task<User> GetUserAsyncById(int userId) => await _users.FirstOrDefaultAsync(u => u.id == userId);

        public async Task<bool> HasPermissionAsync(int permissionId, int roleId) =>
            await _rolePermissions.AnyAsync(r => r.roleId == roleId && r.permissionId == permissionId && !r.IsDeleted);

        public int GetUserRole(string phonenumber) => _users.FirstOrDefault(u => u.Phonenumber == phonenumber).roleId;

        public async Task AddRoleAsync(Role role) => await _roles.AddAsync(role);

        public int SearchRoleAsync(string rolename) =>
            _roles.FirstOrDefault(r => r.rolename == rolename).id;

        public int GetUserIdAsync(string phonenumber) => _users.FirstOrDefault(u => u.Phonenumber == phonenumber)!.id;

        public async Task<List<User>> GetSellersListAsync() =>
            await _users.Where(u => u.roleId == 4).ToListAsync();


    }
}