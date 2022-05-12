using System.Threading.Tasks;

namespace DigiShop.CoreBussiness.EfCoreDomains.OTP
{
    public interface IOtpService
    {
        public string GenerateOtpCode(int len);
        Task AddNewOtpCodeAsync(Otp otp);
        Task<Otp> GetOtpCodeAsync(string code);
    }
}