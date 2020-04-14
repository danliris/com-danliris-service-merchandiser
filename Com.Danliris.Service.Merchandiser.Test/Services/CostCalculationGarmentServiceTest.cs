using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
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
   public class CostCalculationGarmentServiceTest
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
                .Setup(x => x.GetService(typeof(CostCalculationGarment_MaterialService)))
                .Returns(new CostCalculationGarment_MaterialService(serviceProvider.Object));

            //serviceProvider
            //   .Setup(x => x.GetService(typeof(AzureImageService)))
            //   .Returns(new AzureImageService(serviceProvider.Object));

            return serviceProvider;
        }

     

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment() { Id = 1,RO_Number ="1",Article="article test",Convection="convection", Active = true, Code = "Code test" });
            dbContext.SaveChanges();
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = CostCalculationGarmentServiceObj.ReadModel(2, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.CostCalculationGarments.Count());
        }

        

        [Fact]
        public async Task CustomCodeGenerator_When_lastDataIsNull_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 1,
                Active = true,
                Code = "Code test",
                _CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "Convection Test 1",
                _IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Convection = "Convection Test 2",
                _IsDeleted = false
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = await CostCalculationGarmentServiceObj.CustomCodeGenerator(model);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CustomCodeGenerator_withCreatedUtc_DateNow_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 2,
                Active = true,
                Code = "Code test",
                _CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "Convection Test",
                _IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Convection = "Convection Test",
                _IsDeleted = false
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = await CostCalculationGarmentServiceObj.CustomCodeGenerator(model);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CustomCodeGenerator_withCreatedUtc_lesThanNow_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment() {
                Id = 3,
                Active = true,
                Code = "Code test 3",
                _CreatedUtc = DateTime.Now.AddYears(-2) ,
                AutoIncrementNumber = 1,
                Convection = "Convection Test 3",
                _IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Convection = "Convection Test 3",
                _IsDeleted = false
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = await CostCalculationGarmentServiceObj.CustomCodeGenerator(model);
            Assert.NotNull(result);
        }

        //not implement error
        //[Fact]
        //public async Task CreateModel_Return_Succes()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);
        //    dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
        //    {
        //        Id = 3,
        //        Active = true,
        //        Code = "Code test 3",
        //        _CreatedUtc = DateTime.Now,
        //        AutoIncrementNumber = 1,
        //        Convection = "Convection Test 3",
        //        _IsDeleted = false
        //    });
        //    dbContext.SaveChanges();

        //    CostCalculationGarment model = new CostCalculationGarment()
        //    {
        //        Id=3,
        //        Code = "Code test",
        //        CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName = "Category name sample" } },
        //    };
        //    CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

        //    var result = await CostCalculationGarmentServiceObj.CreateModel(model);

        //}



        //[Fact]
        //public async Task DeleteModel_Succes()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);
        //    dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
        //    {
        //        Id = 3,
        //        Active = true,
        //        Code = "Code test 3",
        //        _CreatedUtc = DateTime.Now.AddYears(-2),
        //        AutoIncrementNumber = 1,
        //        Convection = "Convection Test 3",
        //        _IsDeleted = false,
        //        RO_GarmentId = null,
        //        ImagePath = "ImagePath.jpg",
        //    });
        //    dbContext.SaveChanges();

        //    CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

        //    var result = await CostCalculationGarmentServiceObj.DeleteModel(1);
        //}


        //[Fact]
        //public async Task ReadModelById_Succes()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);
        //    dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
        //    {
        //        Id = 3,
        //        Active = true,
        //        Code = "Code test 3",
        //        _CreatedUtc = DateTime.Now.AddYears(-2),
        //        AutoIncrementNumber = 1,
        //        Convection = "Convection Test 3",
        //        _IsDeleted = false,
        //        RO_GarmentId = null,
        //        ImagePath = "ImagePath.jpg",
        //    });
        //    dbContext.SaveChanges();

        //    CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

        //    var result = await CostCalculationGarmentServiceObj.ReadModelById(1);
        //}



        //[Fact]
        //public async Task UpdateModel_Succes()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);
        //    dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
        //    {
        //        Id = 3,
        //        Active = true,
        //        Code = "Code test 3",
        //        _CreatedUtc = DateTime.Now.AddYears(-2),
        //        AutoIncrementNumber = 1,
        //        Convection = "Convection Test 3",
        //        _IsDeleted = false,
        //        RO_GarmentId = null,
        //        ImagePath = "ImagePath.jpg",
        //    });
        //    dbContext.SaveChanges();

        //    CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

        //    CostCalculationGarment model = new CostCalculationGarment()
        //    {

        //    };

        //    var result = await CostCalculationGarmentServiceObj.UpdateModel(1, model);
        //}




        //[Fact]
        //public void Should_Success_OnCreating()
        //{
        //    string testName = GetCurrentMethod();
           
        //    CostCalculationGarment model = new CostCalculationGarment()
        //    {

        //        CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName = "Category name sample" } },
        //    };
        //    CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

        //    CostCalculationGarmentServiceObj.OnCreating(model);

        //}
        

        [Fact]
        public void MapToViewModel_Return_Succes()
        {
            string testName = GetCurrentMethod();
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarment model = new CostCalculationGarment() {

                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName="Category name sample" } },
            };

            var result =CostCalculationGarmentServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarmentViewModel viewModel = new CostCalculationGarmentViewModel()
            {
                Convection = "convectiontest",
                FabricAllowance = 1.0,
                AccessoriesAllowance = 1.0,
                SizeRange = "SizeRange test",
                Buyer = new BuyerViewModel() { _id = "1", name = "name" },
                Efficiency = new EfficiencyViewModel() { Id = 1, Value = 1.0 },
                UOM = new UOMViewModel() { _id = "1", code = "code test", unit = "unit test" },
                Wage = new RateViewModel() { Id = 1, Value = 1.0 },
                Commodity = new MasterPlanComodityViewModel() { _id = "", name = "name test" },
                CommodityDescription = "CommodityDescription test",
                THR = new RateViewModel() { Id = 1, Value = 1.0 },
                Rate = new RateViewModel() { Id = 1, Value = 1.0 },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>() {
                new CostCalculationGarment_MaterialViewModel(){Product = new GarmentProductViewModel(), 
                    Category = new CategoryViewModel(){_id ="1",SubCategory="SubCategory test" ,name ="name" },
                UOMQuantity =new UOMViewModel(){ _id="1",unit="unit test"},
                UOMPrice =new UOMViewModel(){_id="id test",unit="unit test"},
                ShippingFeePortion =1.0,
                }
                },
               
                CommissionPortion =1.0,
                Risk = 1.0,
                OTL1 =new RateCalculatedViewModel() { Id=1,Value =1.0, CalculatedValue =1.0},
                OTL2 = new RateCalculatedViewModel() { Id=1, Value=1, CalculatedValue=1.0},
                NETFOBP =1.0,
            };


           var result = CostCalculationGarmentServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
