using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.DocumentServices
{
    public class DocumentService:IDocumentService
    {
        private DbSet<Document> _documents;

        public DocumentService(IUnitOfWork work)
        {
            _documents = work.Set<Document>();
        }
        public async Task InsertDocumentAsync(Document document) => await _documents.AddAsync(document);

        public async Task<bool> HasUncertainAsync(int userId) =>
            await _documents.AnyAsync(c => c.userId == userId && c.AuthStatus == AuthStatus.None);

        public async Task<List<Document>> DocumentListAsync(int userId) =>
            await _documents.Where(d => d.userId == userId).ToListAsync();

        public async Task<Document> GetDocumentAsync(int docId) =>
            await _documents.Include(c=>c.User).FirstOrDefaultAsync(d => d.id == docId);



    }
}