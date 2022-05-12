using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiShop.CoreBussiness.EfCoreDomains.Documents
{
    public interface IDocumentService
    {
        Task InsertDocumentAsync(Document document);
        Task<bool> HasUncertainAsync(int userId);
        Task<List<Document>> DocumentListAsync(int userId);
        Task<Document> GetDocumentAsync(int docId);
        
    }
}