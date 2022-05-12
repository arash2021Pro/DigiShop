using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DigiShop.SysCoreServices.FileHandlers
{
    public interface IFileManager
    {
        Task<(bool IsDone, string Message)> UploadImageAsync(IWebHostEnvironment environment,string parentfile,string childfile,IFormFile file,int storeId);
        Task<byte[]> DownloadImageAsync(IWebHostEnvironment environment,string parentfile,string childfile,int storeId);
        Task<(bool IsDone, string Message)> UploadImageAsync(IWebHostEnvironment environment,string parentfile,string childfile,string extention,IFormFile file);

        Task<byte[]> DownloadImageAsync(IWebHostEnvironment environment, string parentfile,
            string childfile, string extention);
    }
}