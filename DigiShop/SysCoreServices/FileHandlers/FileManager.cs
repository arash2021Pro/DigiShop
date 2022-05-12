using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DigiShop.SysCoreServices.FileHandlers
{
    public class FileManager:IFileManager
    {
        public async Task<(bool IsDone,string Message)> UploadImageAsync(IWebHostEnvironment environment,string parentfile,string childfile,IFormFile file,int storeId)
        {
            if (file.Length == 0 || file == null)
            {
                return (false, "فایل موجود نیست");
            }
            var filename =  storeId + Path.GetExtension(file.FileName) ;
            var filepath = Path.Combine(environment.WebRootPath,$"{parentfile+"/"+childfile}",filename);
            await using (var filestream = new FileStream(filepath,FileMode.Create))
            {
                await file.CopyToAsync(filestream);
            }
            return (true, "موفق");
        }
        public async Task<byte[]> DownloadImageAsync(IWebHostEnvironment environment, string parentfile, string childfile,  int storeId)
        {
            var path = Path.Combine(environment.WebRootPath, $"{parentfile + "/" + childfile}", storeId + ".jpg");
            FileInfo fileInfo = new FileInfo(path);
            byte[] data = new byte[fileInfo.Length];
            using (FileStream fs = fileInfo.OpenRead())
            {
               await fs.ReadAsync(data, 0, data.Length);
            }
            return data;
        }

        public async Task <(bool IsDone, string Message)> UploadImageAsync(IWebHostEnvironment environment, string parentfile, string childfile, string extention, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return (false,"فایل خالی");
            var filename = extention + Path.GetExtension(file.FileName);
            var filepath = Path.Combine(environment.WebRootPath, $"{parentfile + "/" + childfile}", filename);
            
            await using var filestream = new FileStream(filepath,FileMode.Create);
            await file.CopyToAsync(filestream);
            return (true, "تامام");
        }

        public async Task<byte[]> DownloadImageAsync(IWebHostEnvironment environment, string parentfile, string childfile, string extention)
        {
            var path = Path.Combine(environment.WebRootPath, $"{parentfile + "/" + childfile}", extention + ".jpg");
            FileInfo fileInfo = new FileInfo(path);
            byte[] data = new byte[fileInfo.Length];
            using (FileStream fs = fileInfo.OpenRead())
            {
                await fs.ReadAsync(data, 0, data.Length);
            }
            return data;
        }
    }
}