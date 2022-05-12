using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using Microsoft.AspNetCore.Mvc;

namespace DigiShop.ViewComponents
{
    public class SubCategoryComponent:ViewComponent
    {
        public IStoreService _StoreService;
        public SubCategoryComponent(IStoreService storeService)
        {
            _StoreService = storeService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("default", await _StoreService.GetSubCategoryListAsync()));
        }
    }
}