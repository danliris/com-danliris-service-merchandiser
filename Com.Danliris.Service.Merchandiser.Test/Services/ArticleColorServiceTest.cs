using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.DataUtilities;
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
  public  class ArticleColorServiceTest
    {
        private const string ENTITY = "ArticleColorService";

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

        private ArticleColorDataUtil _dataUtil(ArticleColorService service)
        {

            return new ArticleColorDataUtil(service);
        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();

             var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            dbContext.ArticleColors.Add(new ArticleColor() { Id = 1, Active = true, Name = "Name Test"});
            dbContext.SaveChanges();
            var result = ArticleColorServiceObj.ReadModel(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");

            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.ArticleColors.Count());
        }

       

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            var model = _dataUtil(ArticleColorServiceObj).GetArticleColorModel();
            var result = ArticleColorServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
         
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            var viewModel = _dataUtil(ArticleColorServiceObj).GetArticleColorViewModel();

            var result = ArticleColorServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }

        [Fact]
        public void Read_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            dbContext.ArticleColors.Add(new ArticleColor() { Id = 1, Active = true, Name = "Name Test" });
            dbContext.SaveChanges();

            var result = ArticleColorServiceObj.Read(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");
            Assert.NotNull(result);

        }

        [Fact]
        public async void CreateAsync_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            ArticleColor model = new ArticleColor() { Id = 43, Active = true, Name = "Name Test" };
            var result =await ArticleColorServiceObj.CreateAsync(model);
            Assert.NotNull(result);

        }

        [Fact]
        public async void UpdateAsync_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            
            ArticleColor model = new ArticleColor() { 
                Id = 42, 
                Active = true,
                Name = "Name Test" 
            };

            dbContext.ArticleColors.Add(model);
            dbContext.SaveChanges();


            ArticleColor new_model = new ArticleColor()
            {
                Id = 42,
                Active = true,
                Name = "Name Test"
            };

            var result =await  ArticleColorServiceObj.UpdateAsync(42, new_model);
            Assert.NotNull(result);

        }

        [Fact]
        public async void DeleteAsync_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);

            ArticleColor model = new ArticleColor()
            {
                Id = 44,
                Active = true,
                Name = "Name Test"
            };

            dbContext.ArticleColors.Add(model);
            dbContext.SaveChanges();

            var result = await ArticleColorServiceObj.DeleteAsync(44);
            Assert.NotNull(result);

        }

        [Fact]
        public async void ReadByIdAsync_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);

            ArticleColor model = new ArticleColor()
            {
                Id = 45,
                Active = true,
                Name = "Name Test"
            };

            dbContext.ArticleColors.Add(model);
            dbContext.SaveChanges();

            var result = await ArticleColorServiceObj.ReadByIdAsync(45);
            Assert.NotNull(result);

        }

    }
}
