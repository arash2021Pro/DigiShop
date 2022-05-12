namespace DigiShop.InfraStructure.MailkitServices
{
    public class SmtpOptions
    {
        public string Username { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public bool SSL { get; set; }
        public int Port { get; set; }
    }
}