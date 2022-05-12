using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace DigiShop.InfraStructure.MailkitServices
{
    public class MailkitService:IEmailSendMessage
    {
        private SmtpOptions _options;
        public MailkitService(IOptionsSnapshot<SmtpOptions> options)
        {
            _options = options.Value;
        }
     
        public void SendEmail(string email, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("arashmadadi293@gmail.com", "Digishop");
            message.To.Add(email);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient(_options.Host))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Port = _options.Port;
                smtp.Credentials = new NetworkCredential("arashmadadi293@gmail.com","money20202001love");
                smtp.EnableSsl = _options.SSL; 
                smtp.Send(message);
            }
        }
    }
    
}