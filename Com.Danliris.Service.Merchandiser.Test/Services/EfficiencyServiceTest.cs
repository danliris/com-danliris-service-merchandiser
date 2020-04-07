using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
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
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
    public class EfficiencyServiceTest
    {
        private const string ENTITY = "EfficiencyService";

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

        private EfficiencyDataUtil _dataUtil(EfficiencyService service)
        {
            return new EfficiencyDataUtil(service);
        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();

            var dbContext = _dbContext(testName);

            dbContext.Efficiencies.Add(new Efficiency() { Id = 1, Active = true, Name = "Name Test" ,Code= "code test",Value=20, FinalRange =10, InitialRange=10, _CreatedAgent="created agen",_CreatedBy="ade"});
            dbContext.SaveChanges();

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);

            var result = EfficiencyServiceObj.ReadModel(1, 25, "{}", new List<string>() { "selecttest" },null, "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.Efficiencies.Count());

        }


        [Fact]
        public void Should_Success_OnCreating()
        {
            string testName = GetCurrentMethod();

            Efficiency model = new Efficiency()
            {
                Code = "anycode"
            };
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);

            EfficiencyServiceObj.OnCreating(model);
        }


        [Fact]
        public void Should_Success_OnUpdating()
        {
            string testName = GetCurrentMethod();

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var model = _dataUtil(EfficiencyServiceObj).GetEfficiencyModel();
            EfficiencyServiceObj.OnUpdating(2,model);
        }

        [Fact]
        public async Task ReadModelByQuantity_when_Result_Zero()
        {
            string testName = GetCurrentMethod();
           
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.ReadModelByQuantity(1);
            Assert.Equal(0, result.Id);
            Assert.Equal(0, result.Value);
        }



        [Fact]
        public async Task ReadModelByQuantity_Return_Success()
        {
            string testName = GetCurrentMethod();

            var dbContext = _dbContext(testName);

            dbContext.Efficiencies.Add(new Efficiency() { Id = 1, Active = true, Name = "Name Test", Code = "code test", Value = 20, FinalRange = 50, InitialRange = 10, _CreatedAgent = "created agen", _CreatedBy = "ade", _IsDeleted=false });
            dbContext.SaveChanges();

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.ReadModelByQuantity(30);
            Assert.NotNull(result);
        }

       

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
           
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var model = _dataUtil(EfficiencyServiceObj).GetEfficiencyModel();
            var result = EfficiencyServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
           
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var viewModel = _dataUtil(EfficiencyServiceObj).GetEfficiencyViewModel();
            var result = EfficiencyServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }


    }
}
