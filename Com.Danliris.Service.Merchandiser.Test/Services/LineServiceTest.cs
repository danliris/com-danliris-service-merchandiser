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
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
    public class LineServiceTest
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

            LineService LineServiceObj = new LineService(GetServiceProvider(testName).Object);

            dbContext.Lines.Add(new Line() { Code = "test", Name = "test ", CreatedAgent = "ade", CreatedBy = "ade", LastModifiedAgent = "ade", LastModifiedBy = "ade" });
            dbContext.SaveChanges();

            var result = LineServiceObj.ReadModel(1, 25, "{}", new List<string>() { "test ade" }, "test ", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.Lines.Count());

        }

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            Line model = new Line();
            LineService LineServiceObj = new LineService(GetServiceProvider(testName).Object);
            var result = LineServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            LineViewModel viewModel = new LineViewModel();
            LineService LineServiceObj = new LineService(GetServiceProvider(testName).Object);
            var result = LineServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
