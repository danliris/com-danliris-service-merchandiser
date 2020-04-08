using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage
{
    public interface IAzureImageService
    {
        Task<string> UploadMultipleImage(string name, int id, DateTime createdUtc, List<string> imagesFile, string imagesPath);
        Task<string> DownloadImage(string name, string imagePath);
        Task<List<string>> DownloadMultipleImages(string name, string imagesPath);
        Task RemoveMultipleImage(string name, string imagesPath);
    }
}
