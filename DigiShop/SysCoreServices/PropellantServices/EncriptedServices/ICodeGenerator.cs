namespace DigiShop.SysCoreServices.PropellantServices.EncriptedServices
{
    public interface ICodeGenerator
    {
        public string ActivationCodeGenerator();
        public string FactorCodeGenerator();
        public string FileCodeGenerator();
    }
}