using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
   public class CostCalculationGarmentServiceTest
    {
        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_LineServiceService()
        {
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider().Object);

        }

        [Fact]
        public void MapToViewModel_Return_Succes()
        {
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider().Object);

            CostCalculationGarment model = new CostCalculationGarment() {

                CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>() { new CostCalculationGarment_Material() { CategoryName="Category name sample" } },
            };

            CostCalculationGarmentServiceObj.MapToViewModel(model);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            CostCalculationGarmentService CostCalculationGarmentServiceObj = new CostCalculationGarmentService(GetServiceProvider().Object);

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


            CostCalculationGarmentServiceObj.MapToModel(viewModel);
        }
    }
}
