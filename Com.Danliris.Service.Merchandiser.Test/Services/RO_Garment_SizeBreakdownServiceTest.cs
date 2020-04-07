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
    public class RO_Garment_SizeBreakdownServiceTest
    {
        private const string ENTITY = "LineService";

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
                .EnableSensitiveDataLogging(true)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            MerchandiserDbContext dbContext = new MerchandiserDbContext(optionsBuilder.Options);

            return dbContext;
        }

        public Mock<IServiceProvider> GetServiceProvider(string testname)
        {
            var serviceProvider = new Mock<IServiceProvider>();


            serviceProvider.Setup(s => s.GetService(typeof(MerchandiserDbContext)))
                .Returns(_dbContext(testname));

            serviceProvider.Setup(s => s.GetService(typeof(RO_Garment_SizeBreakdown_DetailService)))
               .Returns(new RO_Garment_SizeBreakdown_DetailService(serviceProvider.Object));

            return serviceProvider;


        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();

            var dbContext = _dbContext(testName);

            RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider(testName).Object);

            dbContext.RO_Garment_SizeBreakdowns.Add(new RO_Garment_SizeBreakdown() { Code = "test", _CreatedAgent = "ade", _CreatedBy = "ade", _LastModifiedAgent = "ade", _LastModifiedBy = "ade" });
            dbContext.SaveChanges();
            var result = RO_Garment_SizeBreakdownServiceObj.ReadModel(1, 25, "{}", new List<string>() { "test ade" }, "test ", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.RO_Garment_SizeBreakdowns.Count());

        }


        //duplicate key
        //[Fact]
        //public void Should_Success_OnDeleting()
        //{
        //    string testName = GetCurrentMethod();

        //    var dbContext = _dbContext(testName);

        //    dbContext.RO_Garment_SizeBreakdowns.Add(new RO_Garment_SizeBreakdown()
        //    {
        //        Id = 2,
        //        Code = "codetest",
        //        _CreatedAgent = "created agent test",
        //        _CreatedBy = "ade",
        //        _LastModifiedAgent = "last modofied test",
        //        _LastModifiedBy = "ade",
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
        //        {
        //            new RO_Garment_SizeBreakdown_Detail()
        //            {
        //                Id=5,
        //                //RO_Garment_SizeBreakdownId=1
        //            },

        //        }

        //    });
        //    dbContext.SaveChanges();

        //    RO_Garment_SizeBreakdown model = new RO_Garment_SizeBreakdown()
        //    {
        //        Id = 2,
        //        Code = "Q1XT4ZG7",
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>() {
        //            new RO_Garment_SizeBreakdown_Detail() {
        //            Id =5,
        //            //RO_Garment_SizeBreakdownId=5,
        //        } }

        //    };

        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider(testName).Object);

        //    RO_Garment_SizeBreakdownServiceObj.OnDeleting(model);
        //}


        //[Fact]
        //public void OnCreating_Return_Success()
        //{
        //    string testName = GetCurrentMethod();

        //    RO_Garment_SizeBreakdown model = new RO_Garment_SizeBreakdown()
        //    {
        //        Code = "Q1XT4ZG7",
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>() { new RO_Garment_SizeBreakdown_Detail() { } }

        //    };
        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider(testName).Object);

        //    RO_Garment_SizeBreakdownServiceObj.OnCreating(model);
        //}


        //[Fact]
        //public void OnUpdating_Return_Success()
        //{
        //    string testName = GetCurrentMethod();

        //    RO_Garment_SizeBreakdown model = new RO_Garment_SizeBreakdown()
        //    {
        //        Code = "Q1XT4ZG7",
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>() { new RO_Garment_SizeBreakdown_Detail() { } }

        //    };
        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider(testName).Object);

        //    RO_Garment_SizeBreakdownServiceObj.OnUpdating(1,model);
        //}


        //[Fact]
        //public void MapToViewModel_Return_Success()
        //{
        //    RO_Garment_SizeBreakdown model = new RO_Garment_SizeBreakdown()
        //    {
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>() { new RO_Garment_SizeBreakdown_Detail() { RO_Garment_SizeBreakdownId = 1 } }
        //    };
        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider().Object);
        //    var result = RO_Garment_SizeBreakdownServiceObj.MapToViewModel(model);
        //    Assert.NotNull(result);
        //}


        //[Fact]
        //public void MapToModel_Return_Success()
        //{
        //    RO_Garment_SizeBreakdownViewModel viewmodel = new RO_Garment_SizeBreakdownViewModel()
        //    {
        //        Color = new ArticleColorViewModel() {Id=1,Name="nama"},
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_DetailViewModel>() { new RO_Garment_SizeBreakdown_DetailViewModel() { } }
        //    };
        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider().Object) {

        //    };


        //    var result = RO_Garment_SizeBreakdownServiceObj.MapToModel(viewmodel);
        //    Assert.NotNull(result);
        //}

    }
}
