using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.CoreBussiness.RepsPattern
{
    public interface IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity:class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken  = new CancellationToken() );
    }
}