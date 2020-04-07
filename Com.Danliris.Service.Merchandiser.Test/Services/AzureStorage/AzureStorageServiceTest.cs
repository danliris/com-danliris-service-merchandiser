using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services.AzureStorage
{
  public  class AzureStorageServiceTest
    {

        private const string ENTITY = "AzureStorageService";

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", ENTITY);
        }

       


        public Mock<IServiceProvider> GetServiceProvider(string testname)
        {

            var serviceProvider = new Mock<IServiceProvider>();
            //serviceProvider.Setup(s => s.GetService(typeof(MerchandiserDbContext)))
            //    .Returns(_dbContext(testname));

            return serviceProvider;
        }

        //[Fact]
        //public void Should_Success_Instantiate_AzureStorageService()
        //{
        //    string testName = GetCurrentMethod();

        //    AzureStorageService ass = new AzureStorageService(GetServiceProvider(testName).Object);

        //    Assert.NotNull(ass);

        //}
    }
}
