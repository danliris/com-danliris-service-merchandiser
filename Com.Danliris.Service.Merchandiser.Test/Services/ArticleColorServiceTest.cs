using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities.BaseClass;
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
    public class ArticleColorServiceTest
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

            serviceProvider.Setup(s => s.GetService(typeof(IIdentityService)))
                .Returns(new IdentityService() { Username = "test", Token = "test", TimezoneOffset = 7 });


            return serviceProvider;
        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();

            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            dbContext.ArticleColors.Add(new ArticleColor() { Id = 1, Active = true, Name = "Name Test" });
            dbContext.SaveChanges();
            var result = ArticleColorServiceObj.ReadModel(1, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");

            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.ArticleColors.Count());
        }

        [Fact]
        public async void Create_Return_Success()
        {
            string testName = GetCurrentMethod();

            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            var model = new ArticleColor() { Name = "test", Description = "test" };
            var result = await ArticleColorServiceObj.CreateModel(model);
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async void Update_Return_Success()
        {
            string testName = GetCurrentMethod() + "Update";

            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            ArticleColorService ArticleColorServiceObj2 = new ArticleColorService(GetServiceProvider(testName).Object);
            var model = new ArticleColor() { Name = "test", Description = "test" };
            await ArticleColorServiceObj.CreateModel(model);
            var data = ArticleColorServiceObj.ReadModel();
            var updatedModel = data.Item1.FirstOrDefault();
            var result = await ArticleColorServiceObj2.UpdateModel(updatedModel.Id, updatedModel);
            Assert.NotEqual(0, result);
        }

        [Fact]
        public async void Delete_Return_Success()
        {
            string testName = GetCurrentMethod() + "Update";

            var dbContext = _dbContext(testName);
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            var model = new ArticleColor() { Name = "test", Description = "test" };
            await ArticleColorServiceObj.CreateModel(model);
            var data = ArticleColorServiceObj.ReadModel();
            var updatedModel = data.Item1.FirstOrDefault();
            var result = await ArticleColorServiceObj.DeleteModel(updatedModel.Id);
            Assert.NotEqual(0, result);
        }



        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            ArticleColor model = new ArticleColor();
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            var result = ArticleColorServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            ArticleColorViewModel viewModel = new ArticleColorViewModel()
            {

            };
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider(testName).Object);
            var result = ArticleColorServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
