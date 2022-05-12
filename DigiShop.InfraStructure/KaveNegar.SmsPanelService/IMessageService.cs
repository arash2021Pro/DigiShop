using System.Threading.Tasks;

namespace DigiShop.InfraStructure.KaveNegar.SmsPanelService
{
    public interface IMessageService
    {
        Task SendMessageAsync(string sender, string recptor, string message);
    }
}