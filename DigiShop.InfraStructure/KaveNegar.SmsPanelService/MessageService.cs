using System.Threading.Tasks;
using DigiShop.InfraStructure.KaveNegar.SmsPanelService;
using Microsoft.Extensions.Options;

namespace DigiShop.InfraStructure.KaveNegar.SmsPanelService
{
    public class MessageService:IMessageService
    {
        private KavenegerOptions _options;
        public MessageService(IOptionsSnapshot<KavenegerOptions>options)
        {
            _options = options.Value;
        }
        public async Task SendMessageAsync(string sender, string recptor, string message)
        {
            var api = new Kavenegar.KavenegarApi(_options.ApiKey);
            await api.Send(sender, recptor, message);
        }
    }
}