using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
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
        public void Should_Success_OnCreating()
        {
            string testName = GetCurrentMethod();
           
            Rate model = new Rate()
            {
                Code = "Q1XT4ZG7"
            };
            RateService RateServiceObj = new RateService(GetServiceProvider(testName).Object);
            
            RateServiceObj.OnCreating(model);
        }

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
    }
}
