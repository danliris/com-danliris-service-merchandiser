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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
   public class RateServiceTest
    {
        private const string ENTITY = "RateService";

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
            RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            dbContext.Rates.Add(new Rate() { Id = 1, Active = true, Code = "Code test", Name = "Name Test", Value = 1.0 });
            dbContext.SaveChanges();
            var result = RateServiceObj.ReadModel(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.Rates.Count());
            

        }

        [Fact]
        public void Read_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            dbContext.Rates.Add(new Rate() { Id = 1, Active = true, Code = "Code test", Name = "Name Test", Value = 1.0 });
            dbContext.SaveChanges();
            var result = RateServiceObj.Read(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.Rates.Count());


        }

        // Method not found
        //[Fact]
        //public void Should_Success_OnCreating()
        //{
        //    string testName = GetCurrentMethod();
           
        //    Rate model = new Rate()
        //    {
        //        Code = "Q1XT4ZG7"
        //    };
        //    RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            
        //    RateServiceObj.OnCreating(model);
        //}

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            Rate model = new Rate();
            RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            var result = RateServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            RateViewModel viewModel = new RateViewModel()
            {
                Value = 1.0,
            };
            RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            var result = RateServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteAsync_Return_Success()
        {
            
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
           
            dbContext.Rates.Add(new Rate() { Id = 1, Active = true, Code = "Code test", Name = "Name Test", Value = 1.0 });
            dbContext.SaveChanges();
            RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            var result =await RateServiceObj.DeleteAsync(1);
            Assert.NotNull(result);
        }


        [Fact]
        public async void CreateAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Rate model = new Rate()
            {
                Id = 39,
                Code = "anycode",
                Name = "name test",
            };

            RateService RateServiceServiceObj = new RateService(GetServiceProvider(testName).Object);
            var result = await RateServiceServiceObj.CreateAsync(model);
            Assert.NotNull(result);

        }

        [Fact]
        public async void UpdateAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Rate model = new Rate()
            {
                Id = 40,
                Code = "anycode",
                Name = "name test",
            };
            dbContext.Rates.Add(model);
            dbContext.SaveChanges();

            RateService RateServiceServiceObj = new RateService(GetServiceProvider(testName).Object);
            var result = await RateServiceServiceObj.UpdateAsync(40,model);
            Assert.NotNull(result);

        }

        [Fact]
        public async void ReadByIdAsync_Return_Success()
        {
         
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Rate model = new Rate()
            {
                Id = 41,
                Code = "anycode",
                Name = "name test",
            };
            dbContext.Rates.Add(model);
            dbContext.SaveChanges();

            RateService RateServiceServiceObj = new RateService(GetServiceProvider(testName).Object);
            var result = await RateServiceServiceObj.ReadByIdAsync(41);
            Assert.NotNull(result);

        }

    }
}
