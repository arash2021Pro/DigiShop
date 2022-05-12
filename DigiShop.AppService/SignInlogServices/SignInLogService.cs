using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.SignInlogServices
{
    public class SignInLogService:ISignInLog
    {
        public DbSet<SignInLog> SignInLogs;
        public SignInLogService(IUnitOfWork work)
        {
            SignInLogs = work.Set<SignInLog>();
        }

        public async Task AddNewLogAsync(SignInLog log) => await SignInLogs.AddAsync(log);


    }
}