using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services.AzureStorage
{
   public class AzureImageServiceTest
    {
        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();


            return serviceProvider;
        }

        //[Fact]
        //public void GenerateFileName_Return_Success()
        //{
        //    DateTime _createdUtc = DateTime.Now;
        //    AzureImageService ais = new AzureImageService(GetServiceProvider().Object);
        //    ais.GenerateFileName(1, _createdUtc);

        //}
    }
}
