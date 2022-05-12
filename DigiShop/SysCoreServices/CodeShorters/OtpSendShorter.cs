using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.RepsPattern;
using Hangfire;

namespace DigiKalaShop.ViewModels.OTP
{
    public class OtpSendShorter
    {
        private string code { get; set; }
         private  int userId { get; set; }
        private IOtpService _otpService;
        private IUnitOfWork _work;

        public OtpSendShorter(IOtpService otpService,string code, int UserId, IUnitOfWork work)
        {
            _otpService = otpService;
            this.code = code;
            userId = UserId;
            _work = work;
        }
        public async Task<int> DoProcess()
        {
            var otp = new Otp()
            {
                code = code,
                userId = this.userId
            };
            await _otpService.AddNewOtpCodeAsync(otp);
            return await _work.SaveChangesAsync();
        }

    
    }
}