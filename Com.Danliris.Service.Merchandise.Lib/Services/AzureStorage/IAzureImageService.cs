using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage
{
    public interface IAzureImageService
    {
        Task<string> DownloadImage(string moduleName, string imagePath);
        Task<List<string>> DownloadMultipleImages(string moduleName, string imagesPath);
        Task<string> UploadImage(string moduleName, int id, DateTime _createdUtc, string imageBase64);
        Task<string> UploadMultipleImage(string moduleName, int id, DateTime _createdUtc, List<string> imagesBase64, string beforeImagePaths);
        Task RemoveImage(string moduleName, string imagePath);
        Task RemoveMultipleImage(string moduleName, string imagesPath);
    }
}
