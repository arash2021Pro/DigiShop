using System.Threading.Tasks;

namespace DigiShop.SysCoreServices.DatabaseInitializations
{
    public interface IDatabaseInitializer
    {
        Task SeedData();
    }
}