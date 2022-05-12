using System.Collections.Generic;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;

namespace DigiShop.CoreBussiness.EfCoreDomains.Users
{
    public interface IAccountService
    {
        Task SignupUserAsync(User user);
        Task<User> LoginUserAsync(string phonenumber, string password);
        Task<bool> IsPhonenumberExistsAsync(string phonenumber);
        Task<User> GetUserAsync(string phonenumber);
     
        Task<User> GetUserAsyncById(int userId);
        string GenerateHash(string password);
        Task<bool> HasPermissionAsync(int permissionId,int roleId);
        int GetUserRole(string phonenumber);
        Task AddRoleAsync(Role role);
        int SearchRoleAsync(string rolename);
        int GetUserIdAsync(string phonenumber);
        Task<List<User>> GetSellersListAsync();
    }
}