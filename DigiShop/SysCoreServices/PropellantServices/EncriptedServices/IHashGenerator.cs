namespace DigiShop.SysCoreServices.PropellantServices.EncriptedServices
{
    public interface IHashGenerator
    {
        public string GenerateHash(string password);
    }
}