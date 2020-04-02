using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services.AzureStorage
{
  public  class AzureStorageServiceTest
    {

        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            return serviceProvider;
        }

        //[Fact]
        //public void Should_Success_Instantiate_AzureStorageService()
        //{

         
        //    AzureStorageService ass = new AzureStorageService(GetServiceProvider().Object);
        //    Assert.NotNull(ass);

        //}
    }
}
