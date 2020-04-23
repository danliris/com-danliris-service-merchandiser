using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Exceptions;
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
using System.Reflection;
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
                .Returns(new CostCalculationGarment_MaterialService(serviceProvider.Object) { Username = "Test" });

            var azureImageMock = new Mock<IAzureImageService>();
            azureImageMock.Setup(s => s.DownloadImage(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("anystring");

            azureImageMock.Setup(s => s.UploadImage(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<string>())).ReturnsAsync("https://via.placeholder.com/300/09f/fff.png");
            serviceProvider.Setup(s => s.GetService(typeof(IAzureImageService))).Returns(azureImageMock.Object);

            return serviceProvider;
        }



        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment() { 
                Id = 3, 
                RO_Number = "",
                Article = "article test", 
                Convection = "K2C",
                Active = true, 
                Code = "Code test"
            });
            dbContext.SaveChanges();
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = CostCalculationGarmentServiceObj.ReadModel(3, 25, "{}", new List<string>() { "select test" }, "keyword test", "{}");
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
                Id = 4,
                Active = true,
                Code = "Code test",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Convection = "K2A",
                IsDeleted = false
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = await CostCalculationGarmentServiceObj.CustomCodeGenerator(model);
            Assert.NotNull(result);
        }


        [Fact]
        public void GetConvectionCode_With_K2C_Return_Success()
        {
            string testName = GetCurrentMethod();
            Type type = typeof(CostCalculationGarmentService);
            var CostCalculationGarmentServiceObj = Activator.CreateInstance(type, GetServiceProvider(testName).Object);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "GetConvectionCode" && x.IsPrivate)
            .First();

            string convince_code = "K2C";

            var result = method.Invoke(CostCalculationGarmentServiceObj, new object[] { convince_code });
            Assert.Equal(3,result);

        }

        [Fact]
        public void GetConvectionCode_With_K1A_Return_Success()
        {
            string testName = GetCurrentMethod();
            Type type = typeof(CostCalculationGarmentService);
            var CostCalculationGarmentServiceObj = Activator.CreateInstance(type, GetServiceProvider(testName).Object);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "GetConvectionCode" && x.IsPrivate)
            .First();

            string convince_code = "K1A";

            var result = method.Invoke(CostCalculationGarmentServiceObj, new object[] { convince_code });
            Assert.Equal(4, result);

        }

        [Fact]
        public void GetConvectionCode_With_K1B_Return_Success()
        {
            string testName = GetCurrentMethod();
            Type type = typeof(CostCalculationGarmentService);
            var CostCalculationGarmentServiceObj = Activator.CreateInstance(type, GetServiceProvider(testName).Object);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "GetConvectionCode" && x.IsPrivate)
            .First();

            string convince_code = "K1B";

            var result = method.Invoke(CostCalculationGarmentServiceObj, new object[] { convince_code });
            Assert.Equal(5, result);

        }


        [Fact]
        public async Task CustomCodeGenerator_withCreatedUtc_DateNow_Return_Success()
        {

            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 5,
                Active = true,
                Code = "Code test",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Convection = "K2C",
                IsDeleted = false
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = await CostCalculationGarmentServiceObj.CustomCodeGenerator(model);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CustomCodeGenerator_withCreatedUtc_lesThanNow_Return_Success()
        {

            string testName = GetCurrentMethod();
            testName = testName + "withDiffKey";
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 6,
                Active = true,
                Code = "Code test 6",
                CreatedUtc = DateTime.Now.AddYears(-2),
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Convection = "K2C",
                IsDeleted = false
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);
            var result = await CostCalculationGarmentServiceObj.CustomCodeGenerator(model);
            Assert.NotNull(result);
        }

        //not implement error
        [Fact]
        public async Task CreateModel_Return_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 7,
                Active = true,
                Code = "Code test 4",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false
            });
            dbContext.SaveChanges();

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Id = 7,
                Code = "Code test",
                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName = "Category name sample" } },
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

          //  var result = await CostCalculationGarmentServiceObj.CreateModel(model);
            await Assert.ThrowsAsync<NotImplementedException>(() => CostCalculationGarmentServiceObj.CreateModel(model));

        }



        [Fact]
        public async Task DeleteModel_Throws_DbReferenceNotNullException()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 8,
                Active = true,
                Code = "Code test 8",
                CreatedUtc = DateTime.Now.AddYears(-2),
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false,
                RO_GarmentId = 8,
                ImagePath = "https://via.placeholder.com/300/09f/fff.png",
            });
            dbContext.SaveChanges();

            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            //var result = await CostCalculationGarmentServiceObj.DeleteModel(8);
            await Assert.ThrowsAsync<DbReferenceNotNullException>(() => CostCalculationGarmentServiceObj.DeleteModel(8));
        }


        [Fact]
        public async Task DeleteModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 9,
                Active = true,
                Code = "Code test 9",
                CreatedUtc = DateTime.Now.AddYears(-2),
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false,
                RO_GarmentId = null,
                ImagePath = "https://via.placeholder.com/300/09f/fff.png",
                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() {
                    new CostCalculationGarment_Material()
                {
                        Id=9,
                        Active =false,
                }
                }
            });
            dbContext.SaveChanges();

            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            var result = await CostCalculationGarmentServiceObj.DeleteModel(9);
            Assert.NotNull(result);

        }


        [Fact]
        public async Task ReadModelById_Succes()
        {


            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 10,
                Active = true,
                Code = "Code test 10",
                CreatedUtc = DateTime.Now.AddYears(-2),
                AutoIncrementNumber = 1,
                Convection = "K2C",
                IsDeleted = false,
                RO_GarmentId = null,
                ImagePath = "https://via.placeholder.com/300/09f/fff.png",
            });
            dbContext.SaveChanges();

            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            var result = await CostCalculationGarmentServiceObj.ReadModelById(10);
            Assert.NotNull(result);
        }

        
        //Not Implemented
        [Fact]
        public async Task GeneratePONumbers_When_CategoryNameIsFabric_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 11,
                Active = true,
                Code = "Code test 11",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "K2A",
                IsDeleted = false,
                RO_GarmentId = null,
                ImagePath = "https://via.placeholder.com/300/09f/fff.png",
                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() {
                    new CostCalculationGarment_Material()
                    {
                        Id=11,
                        Active = false,
                        CategoryName ="FABRIC",
                        AutoIncrementNumber=1,
                        Convection ="K2A",
                        CreatedUtc =DateTime.Now,
                         PO_SerialNumber = "",

                    }
                    }
            });
            dbContext.SaveChanges();

            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Id = 11,
                Convection = "K2A",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() {
                    new CostCalculationGarment_Material()
                    {
                        Id =11,
                        Code = "CodeCostCalculationGarment_Material",
                        Active=false,
                        PO_SerialNumber = "",
                        CategoryName ="FABRIC",
                        AutoIncrementNumber=1,
                        Convection= "K2A"
                    }
                }

            };

            // var result = await CostCalculationGarmentServiceObj.UpdateModel(6, model);
            await Assert.ThrowsAsync<NotImplementedException>(() => CostCalculationGarmentServiceObj.UpdateModel(11, model));
        }

        //Not Implemented
        [Fact]
        public async Task GeneratePONumbers_When_CategoryNameIsNotFabric_Succes_Succes()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            dbContext.CostCalculationGarments.Add(new CostCalculationGarment()
            {
                Id = 12,
                Active = true,
                Code = "Code test 12",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                Convection = "K2B",
                IsDeleted = false,
                RO_GarmentId = null,
                ImagePath = "https://via.placeholder.com/300/09f/fff.png",
                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() {
                    new CostCalculationGarment_Material()
                    {
                        Id=12,
                        Active = false,
                        CategoryName ="NOT FABRIC",
                        AutoIncrementNumber=1,
                        Convection ="K2B",
                        CreatedUtc =DateTime.Now,
                         PO_SerialNumber = "",

                    }
                    }
            });
            dbContext.SaveChanges();

            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarment model = new CostCalculationGarment()
            {
                Id = 12,
                Convection = "K2B",
                CreatedUtc = DateTime.Now,
                AutoIncrementNumber = 1,
                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() {
                    new CostCalculationGarment_Material()
                    {
                        Id =12,
                        Code = "CodeCostCalculationGarment_Material",
                        Active=false,
                        PO_SerialNumber = "",
                        CategoryName ="NOT FABRIC",
                        AutoIncrementNumber=1,
                        Convection= "K2B"
                    }
                }

            };

            // var result = await CostCalculationGarmentServiceObj.UpdateModel(6, model);
            await Assert.ThrowsAsync<NotImplementedException>(() => CostCalculationGarmentServiceObj.UpdateModel(12, model));
        }


        [Fact]
        public void Should_Success_OnCreating()
        {
            string testName = GetCurrentMethod();

            CostCalculationGarment model = new CostCalculationGarment()
            {

                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName = "Category name sample" } },
            };
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarmentServiceObj.OnCreating(model);

        }


        [Fact]
        public void MapToViewModel_Return_Succes()
        {
            string testName = GetCurrentMethod();
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarment model = new CostCalculationGarment()
            {

                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName = "Category name sample" } },
            };

            var result = CostCalculationGarmentServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider(testName).Object);

            CostCalculationGarmentViewModel viewModel = new CostCalculationGarmentViewModel()
            {
                Id=13,
                Convection = "K2C",
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

                CommissionPortion = 1.0,
                Risk = 1.0,
                OTL1 = new RateCalculatedViewModel() { Id = 1, Value = 1.0, CalculatedValue = 1.0 },
                OTL2 = new RateCalculatedViewModel() { Id = 1, Value = 1, CalculatedValue = 1.0 },
                NETFOBP = 1.0,
            };


            var result = CostCalculationGarmentServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
