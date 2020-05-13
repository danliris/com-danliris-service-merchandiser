using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage
{
    public class AzureStorageService : IAzureStorageService
    {
        //private readonly IServiceProvider _serviceProvider;
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobContainer _storageContainer;

        public AzureStorageService()
        {
            string storageAccountName = Environment.GetEnvironmentVariable("StorageAccountName");
            string storageAccountKey = Environment.GetEnvironmentVariable("StorageAccountKey");
            string storageContainer = "merchandiser";

            //_serviceProvider = serviceProvider;
           
            _storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, storageAccountKey), useHttps: true);
            _storageContainer = Configure(storageContainer).GetAwaiter().GetResult();
        }

        public CloudBlobContainer GetStorageContainer()
        {
            return _storageContainer;
        }

        private async Task<CloudBlobContainer> Configure(string storageContainer)
        {
            CloudBlobClient cloudBlobClient = _storageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(storageContainer);
            await cloudBlobContainer.CreateIfNotExistsAsync();

            BlobContainerPermissions permissions = SetContainerPermission(true);
            await cloudBlobContainer.SetPermissionsAsync(permissions);

            return cloudBlobContainer;
        }

        private BlobContainerPermissions SetContainerPermission(bool isPublic)
        {
            BlobContainerPermissions permissions = new BlobContainerPermissions();
            if (isPublic)
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            else
                permissions.PublicAccess = BlobContainerPublicAccessType.Off;
            return permissions;
        }
    }
}
