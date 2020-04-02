using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
  public  class RO_GarmentServiceTest
    {

        private MerchandiserDbContext _dbContext(string testName)
        {
            DbContextOptionsBuilder<MerchandiserDbContext> optionsBuilder = new DbContextOptionsBuilder<MerchandiserDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            MerchandiserDbContext dbContext = new MerchandiserDbContext(optionsBuilder.Options);

            return dbContext;
        }

        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            //serviceProvider
            //    .Setup(x => x.GetService(typeof(IHttpClientService)))
            //    .Returns(new HttpClientTestService());

            //serviceProvider
            //    .Setup(x => x.GetService(typeof(IIdentityService)))
            //    .Returns(new IdentityService() { Token = "Token", Username = "Test" });


            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_RO_GarmentService()
        {  
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider().Object);
            //RO_GarmentServiceObj.ReadModel(1, 25, "{}", new List<string>() { "select test" }, "keywors", "{}");
        }


        //[Fact]
        //public void ReadModel_Return_Success()
        //{
        //    RO_Garment rogm = new RO_Garment()
        //    {
        //        CostCalculationGarmentId = 1,
        //    };
        //    RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider().Object);
        //    RO_GarmentServiceObj.OnCreating(rogm);

        //}


        //[Fact]
        //public void MapToViewModel_Return_Success()
        //{
        //    RO_Garment model = new RO_Garment();
        //    RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider().Object);
        //    var result = RO_GarmentServiceObj.MapToViewModel(model);
        //    Assert.NotNull(result);
        //}
    }
}
