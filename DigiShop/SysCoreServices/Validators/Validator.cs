using System;
using System.Threading.Tasks;

namespace DigiShop.SysCoreServices.Validators
{
    public class Validator
    {
        public bool IsGuidValid(string code)
        {
            
            for (int i = 0; i < code.Length; i++)
            {
                var Chars = code[i];
                if (char.IsLower(Chars) && char.IsDigit(Chars) && code.Length == 6)
                    return true;
            }
            return false;

        }
    }
}