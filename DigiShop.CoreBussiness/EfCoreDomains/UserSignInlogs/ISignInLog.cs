using System.Threading.Tasks;

namespace DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs
{
    public interface ISignInLog
    {
        Task AddNewLogAsync(SignInLog log);
    }
}