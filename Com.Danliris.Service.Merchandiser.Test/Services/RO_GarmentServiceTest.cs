using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.DataUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.WindowsAzure.Storage.Blob;
using Moq;
using Newtonsoft.Json;
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
    public class RO_GarmentServiceTest
    {

        private const string ENTITY = "RO_GarmentService";

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

            serviceProvider.Setup(s => s.GetService(typeof(RO_Garment_SizeBreakdownService)))
               .Returns(new RO_Garment_SizeBreakdownService(serviceProvider.Object));

            serviceProvider.Setup(s => s.GetService(typeof(RO_Garment_SizeBreakdown_DetailService)))
               .Returns(new RO_Garment_SizeBreakdown_DetailService(serviceProvider.Object));

            serviceProvider.Setup(s => s.GetService(typeof(CostCalculationGarmentService)))
              .Returns(new CostCalculationGarmentService(serviceProvider.Object));

            //var azureImageServiceMock = new Mock<AzureImageService>();
            //azureImageServiceMock.Setup(s => s.RemoveImage(It.IsAny<string>(), It.IsAny<string>()));

            //var azureInterface = new Mock<IAzureStorageService>();
            //azureInterface.Setup(s => s.GetStorageContainer()).Returns(new CloudBlobContainer(new Uri("https://via.placeholder.com/300/09f/fff.png")));

            var ICostCalculationGarmentsMock = new Mock<ICostCalculationGarments>();
            ICostCalculationGarmentsMock.Setup(s => s.ReadModelById(It.IsAny<int>())).ReturnsAsync(new CostCalculationGarment());

            serviceProvider.Setup(s => s.GetService(typeof(ICostCalculationGarments)))
             .Returns(ICostCalculationGarmentsMock.Object);

            var ICostCalculationGarment_MaterialServiceMock = new Mock<ICostCalculationGarment_MaterialService>();
            serviceProvider.Setup(s => s.GetService(typeof(ICostCalculationGarment_MaterialService)))
            .Returns(ICostCalculationGarment_MaterialServiceMock.Object);
            

            var azureImage = new Mock<IAzureImageService>();
            azureImage.Setup(s => s.DownloadImage(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("anystring");

            serviceProvider.Setup(s => s.GetService(typeof(IAzureImageService)))
            .Returns(azureImage.Object);



            return serviceProvider;
        }

        private RO_GarmentDataUtil _dataUtil(RO_GarmentService service)
        {

            return new RO_GarmentDataUtil(service);
        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            dbContext.RO_Garments.Add(new RO_Garment() { 
                Id = 14, 
                Active = true, 
                Code = "code test",
                _CreatedAgent = "created agen", 
                _CreatedBy = "ade" });
            dbContext.SaveChanges();


            var result = RO_GarmentServiceObj.ReadModel(14, 25, "{}", new List<string>() { "select test" }, "keywors", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.RO_Garments.Count());
        }


        [Fact]
        public void Should_Success_OnCreating()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment() { 
                Id = 15, 
                Active = true, 
                Code = "code test", 
                _CreatedAgent = "created agen",
                _CreatedBy = "ade" 
            });
            dbContext.SaveChanges();

            RO_Garment model = new RO_Garment()
            {
                CostCalculationGarmentId = 1,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){
                            Active = true, 
                            Code ="CodeTest", 
                            Id=15}
                    }

                } },
            };
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            RO_GarmentServiceObj.OnCreating(model);


        }


        //validate not implement
        [Fact]
        public async Task Should_Success_CreateModel()
        {
            string testName = GetCurrentMethod();
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var dbContext = _dbContext(testName);


            var model = _dataUtil(RO_GarmentServiceObj).GetDataFor_CreateModel();
            dbContext.RO_Garments.Add(model);
            dbContext.SaveChanges();

            await Assert.ThrowsAsync<NotImplementedException>(() => RO_GarmentServiceObj.CreateModel(model));


        }


        [Fact]
        public async Task Should_Success_ReadModelById()
        {
            string testName = GetCurrentMethod() ;

            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var dbContext = _dbContext(testName);


            var model = _dataUtil(RO_GarmentServiceObj).GetDataForReadModel();
            dbContext.RO_Garments.Add(model);
            dbContext.SaveChanges();



            var result = await RO_GarmentServiceObj.ReadModelById(21);


        }


        // System.NotImplementedException : The method or operation is not implemented.
        [Fact]
        public async Task Should_Success_UpdateModel()
        {
            string testName = GetCurrentMethod();
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var dbContext = _dbContext(testName);


            var model = _dataUtil(RO_GarmentServiceObj).GetRO_GarmentModel();
            dbContext.RO_Garments.Add(model);
            dbContext.SaveChanges();



            //var result = await RO_GarmentServiceObj.UpdateModel(10, model);
            await Assert.ThrowsAsync<NotImplementedException>(() => RO_GarmentServiceObj.UpdateModel(10, model));


        }

      
        [Fact]
        public async Task Should_Success_DeleteModel()
        {
            string testName = GetCurrentMethod();
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var dbContext = _dbContext(testName);


            var model = _dataUtil(RO_GarmentServiceObj).GetDataForDeleteModel();
            dbContext.RO_Garments.Add(model);
            dbContext.SaveChanges();



            var result = await RO_GarmentServiceObj.DeleteModel(1);
            Assert.NotNull(result);

        }



        [Fact]
        public void OnUpdating_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 23,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=23,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                            Id=23,
                            Code="code detail",
                            Active=true
                        }
                    }
                }
                }
            });
            dbContext.SaveChanges();

            RO_Garment model = new RO_Garment()
            {
                CostCalculationGarmentId = 23,

                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Id=23,
                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){
                             Id=23,
                            Active = true, 
                            Code ="code detail",
                        },

                    }

                } },
            };
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            RO_GarmentServiceObj.OnUpdating(23, model);

        }

        [Fact]
        public void Should_Success_OnUpdating_When_ChildModel_Null()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 17,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=17,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                          //  Id=17,
                            Code="code detail",
                            Active=true
                        }
                    }
                }
                }
            });
            dbContext.SaveChanges();

            RO_Garment model = new RO_Garment()
            {
                CostCalculationGarmentId = 17,

                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Id=0,
                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){
                         //   Id=17,
                            Active = true, 
                            Code ="code detail",
                        },

                    }

                } },
            };
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            RO_GarmentServiceObj.OnUpdating(17, model);


        }



        [Fact]
        public void Should_Success_OnDeleting()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 18,

                //RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                //      Id=18,
                //    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                //    {
                //        new RO_Garment_SizeBreakdown_Detail()
                //        {
                //            Id=18,
                //            Code="code detail",
                //            Active=true
                //        }
                //    }
                //}
                // }
            });
            dbContext.SaveChanges();

            RO_Garment model = new RO_Garment()
            {
                Id = 18,

                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                   Id=18,
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){
                            Id=18,
                            Active = true, 
                            Code ="code detail"},

                    }

                } },
            };
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            RO_GarmentServiceObj.OnDeleting(model);


        }



        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();

            string[] imagepaths = new string[] { "https://via.placeholder.com/300/09f/fff.png" };
            string imagepath = JsonConvert.SerializeObject(imagepaths);

            string[] imagenames = new string[] { "https://via.placeholder.com/300/09f/fff.png" };
            string imagename = JsonConvert.SerializeObject(imagenames);
            var dbContext = _dbContext(testName);

            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 19,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                ImagesPath = imagepath,
                ImagesName = imagename,
                CostCalculationGarment = new CostCalculationGarment() { },
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=19,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                            Id=19,
                            Code="code detail",
                            Active=true
                        }
                    }
                }
                }
            });
            dbContext.SaveChanges();

            RO_Garment model = new RO_Garment()
            {
                Id = 19,
                CostCalculationGarment = new CostCalculationGarment() { },
                ImagesPath =imagepath,
                ImagesName =imagename,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Id=19,
                    Active=true,
                    ColorName ="Red",

                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){
                            Id=19,
                            Active = true, 
                            Code ="code detail"},

                    }

                } },
            };
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var result = RO_GarmentServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }



        [Fact]
        public void MapToModel_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 20,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                CostCalculationGarment = new CostCalculationGarment() { },
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=20,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                            Id=20,
                            Code="code detail",
                            Active=true
                        }
                    }
                }
                }
            });
            dbContext.SaveChanges();

            RO_GarmentViewModel model = new RO_GarmentViewModel()
            {
                Id=20,
                CostCalculationGarment = new CostCalculationGarmentViewModel()
                {
                    Buyer = new BuyerViewModel() { },
                    Efficiency = new EfficiencyViewModel() { },

                    UOM = new UOMViewModel() { },
                    Wage = new RateViewModel() { },
                    Commodity = new MasterPlanComodityViewModel() { },
                    THR = new RateViewModel() { },
                    Rate = new RateViewModel() { },
                    CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                   {
                       new CostCalculationGarment_MaterialViewModel()
                       {
                           Product = new GarmentProductViewModel(){},
                           Category =new CategoryViewModel(){},
                           UOMQuantity=new UOMViewModel(){},
                           UOMPrice= new UOMViewModel(){},

                       }
                   },
                    OTL1 = new RateCalculatedViewModel() { },
                    OTL2 = new RateCalculatedViewModel() { }
                },
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdownViewModel>()
                {
                    new RO_Garment_SizeBreakdownViewModel(){
                   Color =new ArticleColorViewModel(){},
                   RO_Garment_SizeBreakdown_Details=new List<RO_Garment_SizeBreakdown_DetailViewModel>(){
                   new RO_Garment_SizeBreakdown_DetailViewModel()
                   {

                   }
                   }
                    },

                }

            };
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var result = RO_GarmentServiceObj.MapToModel(model);
            Assert.NotNull(result);
        }
    }
}
