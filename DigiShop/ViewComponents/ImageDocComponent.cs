using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using Microsoft.AspNetCore.Mvc;

namespace DigiShop.ViewComponents
{
    public class ImageDocComponent:ViewComponent
    {
        
        private IDocumentService _documentService;
        public ImageDocComponent(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("default", await _documentService.GetDocumentAsync(id)));
        }
        
    }
}