using System;

namespace DigiShop.SysCoreServices.PropellantServices.EncriptedServices
{
    public class CodeGenerator:ICodeGenerator
    {
        public string ActivationCodeGenerator(){ var code = ""; var randome = new Random(); for (int round = 1; round <= 6; round++) { code += randome.Next(1, 10); } return code; }

        public string FactorCodeGenerator(){ var code = ""; var randome = new Random(); for (int round = 1; round <= 6; round++) { code += randome.Next(1, 10); } return code; }

        public string FileCodeGenerator() => Guid.NewGuid().ToString().Replace("-", "").Substring(1, 6);
    }
}