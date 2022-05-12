using System;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.AppService.OtpServices
{
    public class OtpService:IOtpService
    {
        private DbSet<Otp> _otps;

        public OtpService(IUnitOfWork work)
        {
            _otps = work.Set<Otp>();
        }
        public string GenerateOtpCode(int len)
        {
            string StrTemp = "";
            char Char;
            for (int start =48; start < 57; start++)
            {
                Char = (char)start;
                if (char.IsDigit(Char))
                {
                    StrTemp += Char.ToString();
                }
            }
            Random randome = new Random();
            char[] CharLetter = new char[len];
            for (int start = 0; start < len; start++)
            {
                int index = randome.Next(StrTemp.Length);
                CharLetter[start] = StrTemp[index];
            }
            string OtpCode= "";
            for (int index = 0; index < len; index++)
            {
                OtpCode += CharLetter[index];
            }
            return OtpCode;
        }

        public async Task AddNewOtpCodeAsync(Otp otp) => await _otps.AddAsync(otp);

        public async Task<Otp?> GetOtpCodeAsync(string code) => await _otps.SingleOrDefaultAsync(otp => otp.code == code);

    }
}