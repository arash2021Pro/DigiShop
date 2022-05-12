using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.StoreServices
{
    public class StoreService:IStoreService
    {
        public DbSet<Store> _Stores;
        public DbSet<StoreCategory> _StoreCategories;
        private IUnitOfWork _work;
        public StoreService(IUnitOfWork work)
        {
            _work = work;
            _Stores = work.Set<Store>();
            _StoreCategories = work.Set<StoreCategory>();
            ;
        }
        public async Task AddNewStoreAsync(Store store) => await _Stores.AddAsync(store);
        public async Task<bool> IsEmailExistsAsync(string email) => await _Stores.AnyAsync(e => e.Mail == email);
        public async Task<Store> GetStoreAsync(int userId)
        {
            return await _Stores.FirstOrDefaultAsync(s => s.UserId == userId);
        }
        public string GetStoreEmailAsync(int userId) => _Stores.FirstOrDefault(s => s.UserId == userId)!.Mail;

        
        public async Task InsertCategoryAsync(StoreCategory storeCategory) =>
            await _StoreCategories.AddAsync(storeCategory);


        public async Task UpdateCategoryAsync(int categoryId, string categoryname,string icon)
        {
            var category = await GetStoreCategoryAsync(categoryId);
            category.CategoryName = categoryname;
            category.icon = icon;
            await _work.SaveChangesAsync();
        }

        public async Task UpdateSubCategoryAsync(int id, int parentId, string name)
        {
            var category = await GetStoreCategoryAsync(id);
            category.CategoryName = name;
            category.ParentId = parentId;
            await _work.SaveChangesAsync();
        }

        public async Task<StoreCategory> GetStoreCategoryAsync(int categoryId) =>
            await _StoreCategories.SingleOrDefaultAsync(c => c.id == categoryId);


        public async Task<List<StoreCategory>> GetCategoryListAsync(string? searchvalue) =>
            String.IsNullOrEmpty(searchvalue)
                ? await _StoreCategories.Where(c => c.ParentId == null).ToListAsync()
                : await _StoreCategories.Where(c => c.CategoryName == searchvalue && c.ParentId == null).ToListAsync();

        public async Task<bool> IsCategoryExistsAsync(string categoryname) =>
            await _StoreCategories.AnyAsync(c => c.CategoryName == categoryname);
        
        
        public async Task<List<StoreCategory>> GetSubCategoryListAsync() => await _StoreCategories.ToListAsync();
        
        public async Task<List<StoreCategory>> GetStoreCategoryListByParentId(int parentId)=>await _StoreCategories.Where(s => s.ParentId == parentId).ToListAsync();
        
        public async Task DeleteStoreCategoryAsync(int id)
        {
            var category =await _StoreCategories.FirstOrDefaultAsync(c => c.id == id);
            _StoreCategories.Remove(category);
        }

        public async Task<List<Store>> GetStoreListAsync() => await _Stores.Include(x=>x.User).ToListAsync();



    }
}