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

            serviceProvider.Setup(s => s.GetService(typeof(RO_Garment_SizeBreakdownService)))
               .Returns(new RO_Garment_SizeBreakdownService(serviceProvider.Object));

            serviceProvider.Setup(s => s.GetService(typeof(RO_Garment_SizeBreakdown_DetailService)))
               .Returns(new RO_Garment_SizeBreakdown_DetailService(serviceProvider.Object));

            serviceProvider.Setup(s => s.GetService(typeof(CostCalculationGarmentService)))
              .Returns(new CostCalculationGarmentService(serviceProvider.Object));


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
            dbContext.RO_Garments.Add(new RO_Garment() { Id = 1, Active = true, Code = "code test", _CreatedAgent = "created agen", _CreatedBy = "ade" });
            dbContext.SaveChanges();


            var result = RO_GarmentServiceObj.ReadModel(1, 25, "{}", new List<string>() { "select test" }, "keywors", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.RO_Garments.Count());
        }


        [Fact]
        public void Should_Success_OnCreating()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);

            dbContext.RO_Garments.Add(new RO_Garment() { Id = 1, Active = true, Code = "code test", _CreatedAgent = "created agen", _CreatedBy = "ade" });
            dbContext.SaveChanges();

            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var model = _dataUtil(RO_GarmentServiceObj).GetRO_GarmentModel();
            RO_GarmentServiceObj.OnCreating(model);


        }



        //[Fact]
        //public void OnUpdating_Success()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);


        //    dbContext.RO_Garments.Add(new RO_Garment()
        //    {
        //        Id = 1,
        //        Active = true,
        //        Code = "code test",
        //        _CreatedAgent = "created agen",
        //        _CreatedBy = "ade",
        //        RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
        //            Id=2,
        //            Active=true,
        //            Code="code test",
        //            RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
        //            {
        //                new RO_Garment_SizeBreakdown_Detail()
        //                {
        //                    Id=3,
        //                    Code="code detail",
        //                    Active=true
        //                }
        //            }
        //        }
        //        }
        //    });
        //    dbContext.SaveChanges();

        //    RO_Garment model = new RO_Garment()
        //    {
        //        CostCalculationGarmentId = 3,

        //        RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {

        //            Active=true,
        //            ColorName ="Red",
        //            RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
        //            {
        //                new RO_Garment_SizeBreakdown_Detail(){Active = true, Code ="code detail",Id=4},

        //            }

        //        } },
        //    };
        //    RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
        //    RO_GarmentServiceObj.OnUpdating(1, model);

        //}

        [Fact]
        public void Should_Success_OnUpdating_When_ChildModel_Null()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 1,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=2,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                            Id=3,
                            Code="code detail",
                            Active=true
                        }
                    }
                }
                }
            });
            dbContext.SaveChanges();

            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var model = _dataUtil(RO_GarmentServiceObj).GetRO_GarmentModel();
            RO_GarmentServiceObj.OnUpdating(1, model);


        }



        //[Fact]
        //public void Should_Success_OnDeleting()
        //{
        //    string testName = GetCurrentMethod();
        //    var dbContext = _dbContext(testName);


        //    dbContext.RO_Garments.Add(new RO_Garment()
        //    {
                
        //        Id = 9,

        //        RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
        //            RO_GarmentId =9,
        //            Id=10,
        //            RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
        //            {
        //                new RO_Garment_SizeBreakdown_Detail()
        //                {
        //                    Id=10,
        //                    Code="code detail",
        //                    Active=true
        //                }
        //            }
        //        }
        //         }
        //    });
        //   dbContext.SaveChanges();

        //    RO_Garment model = new RO_Garment()
        //    {
        //        Id = 9,

        //        RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
        //            RO_GarmentId =9,
        //           Id=10,
        //            RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
        //            {
        //                new RO_Garment_SizeBreakdown_Detail(){Id=10,Active = true, Code ="code detail"},

        //            }

        //        } },
        //    };
        //    RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
        //    RO_GarmentServiceObj.OnDeleting(model);


        //}



        [Fact]
        public void MapToViewModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);


            dbContext.RO_Garments.Add(new RO_Garment()
            {
                Id = 11,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                CostCalculationGarment = new CostCalculationGarment() { },
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=12,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                            Id=13,
                            Code="code detail",
                            Active=true
                        }
                    }
                }
                }
            });
            dbContext.SaveChanges();

            
            RO_GarmentService RO_GarmentServiceObj = new RO_GarmentService(GetServiceProvider(testName).Object);
            var model = _dataUtil(RO_GarmentServiceObj).GetRO_GarmentModel();
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
                Id = 11,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                CostCalculationGarment = new CostCalculationGarment() { },
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown> { new RO_Garment_SizeBreakdown() {
                    Id=12,
                    Active=true,
                    Code="code test",
                    RO_Garment_SizeBreakdown_Details= new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail()
                        {
                            Id=13,
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
