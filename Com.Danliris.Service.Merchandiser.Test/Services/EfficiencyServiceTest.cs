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

            serviceProvider
              .Setup(x => x.GetService(typeof(IIdentityService)))
              .Returns(new IdentityService() { Token = "Token", Username = "username" });

            return serviceProvider;
        }

        [Fact]
        public void Read_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.Efficiencies.Add(new Efficiency() { Id = 1,
                Active = true, 
                Name = "Name Test", 
                Code = "code test",
                Value = 20, 
                FinalRange = 10,
                InitialRange = 10, 
                CreatedAgent = "created agen",
                CreatedBy = "ade" });
            dbContext.SaveChanges();

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);

            var result = EfficiencyServiceObj.Read(1, 25, "{}", new List<string>() { "selecttest" }, null, "{}");
            Assert.NotNull(result);
           

        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();

            var dbContext = _dbContext(testName);

            dbContext.Efficiencies.Add(new Efficiency() { Id = 1, Active = true, Name = "Name Test" ,Code= "code test",Value=20, FinalRange =10, InitialRange=10, CreatedAgent="created agen",CreatedBy="ade"});
            dbContext.SaveChanges();

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);

            var result = EfficiencyServiceObj.ReadModel(1, 25, "{}", new List<string>() { "selecttest" },null, "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.Efficiencies.Count());

        }

        // Method not found
        //[Fact]
        //public void Should_Success_OnCreating()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);
        //    Efficiency model = new Efficiency()
        //    {
        //        Code = "anycode",
        //        Value = 20,
        //        FinalRange = 10,
        //        InitialRange = 10,
        //        CreatedAgent = "created agen",
        //        CreatedBy = "ade"
        //    };

        //    dbContext.Efficiencies.Add(model);
        //    dbContext.SaveChanges();
        //    EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);

        //    EfficiencyServiceObj.OnCreating(model);
        //}

        // Method not found
        //[Fact]
        //public void Should_Success_OnUpdating()
        //{
        //    string testName = GetCurrentMethod();

        //    Efficiency model = new Efficiency()
        //    {
        //        Code = "anycode",
        //        InitialRange = 10,
        //        FinalRange = 20,
        //        Name = "name test",
        //        LastModifiedBy= "ade",
        //    };
        //    EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);

        //    EfficiencyServiceObj.OnUpdating(2,model);
        //}

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

            dbContext.Efficiencies.Add(new Efficiency() { Id = 1, Active = true, Name = "Name Test", Code = "code test", Value = 20, FinalRange = 50, InitialRange = 10, CreatedAgent = "created agen", CreatedBy = "ade", IsDeleted=false });
            dbContext.SaveChanges();

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.ReadModelByQuantity(30);
            Assert.NotNull(result);
        }

       

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            Efficiency model = new Efficiency();
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = EfficiencyServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            EfficiencyViewModel viewModel = new EfficiencyViewModel()
            {
                InitialRange = 1,
                FinalRange =1,
                Value=1
            };
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = EfficiencyServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }

        [Fact]
        public async void CreateAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Efficiency model = new Efficiency()
            {
                Id = 42,
                Code = "anycode",
                InitialRange = 10,
                FinalRange = 20,
                Name = "name test",
            };
          
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.CreateAsync(model);
            Assert.NotNull(result);

        }

        [Fact]
        public async void ReadByIdAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Efficiency model = new Efficiency()
            {
                Id = 36,
                Code = "anycode",
                InitialRange = 10,
                FinalRange = 20,
                Name = "name test",
            };
            dbContext.Efficiencies.Add(model);
            dbContext.SaveChanges();
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.ReadByIdAsync(36);
            Assert.NotNull(result);

        }


        [Fact]
        public async void DeleteAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Efficiency model = new Efficiency()
            {
                Id = 37,
                Code = "anycode",
                InitialRange = 10,
                FinalRange = 20,
                Name = "name test",
            };
            dbContext.Efficiencies.Add(model);
            dbContext.SaveChanges();
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.DeleteAsync(37);
            Assert.NotNull(result);

        }

        [Fact]
        public async void UpdateAsync_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            Efficiency model = new Efficiency()
            {
                Id = 38,
                Code = "anycode",
                InitialRange = 10,
                FinalRange = 20,
                Name = "name test",
            };
            dbContext.Efficiencies.Add(model);
            dbContext.SaveChanges();

            Efficiency new_model = new Efficiency()
            {
                Id = 38,
                Code = "anycode",
                InitialRange = 10,
                FinalRange = 20,
                Name = "name test",
            };
            dbContext.Efficiencies.Add(model);

            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider(testName).Object);
            var result = await EfficiencyServiceObj.UpdateAsync( 38, new_model);
            Assert.NotNull(result);

        }
    }
}
