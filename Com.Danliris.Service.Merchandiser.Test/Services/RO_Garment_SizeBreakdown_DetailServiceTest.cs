using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
   public class RO_Garment_SizeBreakdown_DetailServiceTest
    {
        private const string ENTITY = "RO_Garment_SizeBreakdown_DetailService";

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", ENTITY);
        }

        private MerchandiserDbContext _dbContext(string testName)
        {
            DbContextOptionsBuilder<MerchandiserDbContext> optionsBuilder = new DbContextOptionsBuilder<MerchandiserDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            MerchandiserDbContext dbContext = new MerchandiserDbContext(optionsBuilder.Options);

            return dbContext;
        }

        public Mock<IServiceProvider> GetServiceProvider(string testname)
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(s => s.GetService(typeof(MerchandiserDbContext)))
                .Returns(_dbContext(testname));

            serviceProvider
              .Setup(x => x.GetService(typeof(IIdentityService)))
              .Returns(new IdentityService() { Token = "Token", Username = "username" });

            return serviceProvider;
        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.RO_Garment_SizeBreakdown_Details.Add(new RO_Garment_SizeBreakdown_Detail() { Id = 1, Active = true, Code = "Code test" });
            dbContext.SaveChanges();
            RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider(testName).Object);
            var result = RO_Garment_Size_Detail_ServiceObj.ReadModel(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");
            

        }

        // Method not found
        //[Fact]
        //public void Should_Success_OnCreating()
        //{
        //    string testName = GetCurrentMethod();

        //    RO_Garment_SizeBreakdown_Detail model = new RO_Garment_SizeBreakdown_Detail()
        //    {
        //        Code = "anycode"
        //    };
        //    RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider(testName).Object);

        //    RO_Garment_Size_Detail_ServiceObj.OnCreating(model);
        //}

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            RO_Garment_SizeBreakdown_Detail model = new RO_Garment_SizeBreakdown_Detail();
            RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider(testName).Object);
            var result = RO_Garment_Size_Detail_ServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            RO_Garment_SizeBreakdown_DetailViewModel viewmodel = new RO_Garment_SizeBreakdown_DetailViewModel();
            RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider(testName).Object);
            var result = RO_Garment_Size_Detail_ServiceObj.MapToModel(viewmodel);
            Assert.NotNull(result);
        }


        [Fact]
        public async void ReadByIdAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            RO_Garment_SizeBreakdown_Detail model = new RO_Garment_SizeBreakdown_Detail()
            {
                Id = 41,
               
            };
            dbContext.RO_Garment_SizeBreakdown_Details.Add(model);
            dbContext.SaveChanges();

            RO_Garment_SizeBreakdown_DetailService RO_Garment_SizeBreakdown_DetailServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider(testName).Object);
          //  var result = await RO_Garment_SizeBreakdown_DetailServiceObj.ReadByIdAsync(41);
            await Assert.ThrowsAsync<NotImplementedException>(() => RO_Garment_SizeBreakdown_DetailServiceObj.ReadByIdAsync(41));

        }


        [Fact]
        public void Read_Return_NotImplementedException()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            RO_Garment_SizeBreakdown_Detail model = new RO_Garment_SizeBreakdown_Detail()
            {
                Id = 41,

            };
            dbContext.RO_Garment_SizeBreakdown_Details.Add(model);
            dbContext.SaveChanges();

            RO_Garment_SizeBreakdown_DetailService RO_Garment_SizeBreakdown_DetailServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider(testName).Object);
             
           Assert.Throws<NotImplementedException>(() => RO_Garment_SizeBreakdown_DetailServiceObj.Read(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}"));

        }
    }
}
