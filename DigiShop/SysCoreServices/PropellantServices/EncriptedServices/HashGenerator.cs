using System;
using System.Security.Cryptography;
using System.Text;

namespace DigiShop.SysCoreServices.PropellantServices.EncriptedServices
{
    public class HashGenerator:IHashGenerator
    {
        public string GenerateHash(string password)
        {
            if (String.IsNullOrEmpty(password))
                return "";
            using (var sha = new SHA512Managed())
            {
                var bytes = Encoding.ASCII.GetBytes(password);
                var encripted = sha.ComputeHash(bytes);
                return  Encoding.ASCII.GetString(encripted);
            }
        } 
    }
}