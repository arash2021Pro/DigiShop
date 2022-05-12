namespace DigiShop.InfraStructure.MailkitServices
{
    public interface IEmailSendMessage
    {
        public void SendEmail(string email, string subject, string body);
    }
}