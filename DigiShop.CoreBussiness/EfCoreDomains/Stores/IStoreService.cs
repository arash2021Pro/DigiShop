using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;

namespace DigiShop.CoreBussiness.EfCoreDomains.Stores
{
    public interface IStoreService
    {
        Task AddNewStoreAsync(Store store);
        Task<bool> IsEmailExistsAsync(string email);
        Task<Store> GetStoreAsync(int userId);
        string GetStoreEmailAsync(int userId);
        Task InsertCategoryAsync(StoreCategory storeCategory);
        Task UpdateCategoryAsync(int categoryId, string categoryname,string icon);
        Task UpdateSubCategoryAsync(int id, int parentId, string name);
        Task<StoreCategory> GetStoreCategoryAsync(int categoryId);
        Task<List<StoreCategory>> GetCategoryListAsync(string? searchvalue);
        Task<bool> IsCategoryExistsAsync(string categoryname);
        Task<List<StoreCategory>> GetSubCategoryListAsync();
        Task<List<StoreCategory>> GetStoreCategoryListByParentId(int parentId);
        Task DeleteStoreCategoryAsync(int id);
        Task<List<Store>> GetStoreListAsync();

    }
}