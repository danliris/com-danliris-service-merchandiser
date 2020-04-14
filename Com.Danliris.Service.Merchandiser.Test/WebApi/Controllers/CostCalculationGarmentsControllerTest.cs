using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.WebApi.Utils;
using Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.WebApi.Controllers
{
    public class CostCalculationGarmentControllerTest : BasicControllerTest<CostCalculationGarmentsController, CostCalculationGarment, CostCalculationGarmentViewModel, ICostCalculationGarments>

    {

        [Fact]
        public void Get_PDF_NotFound()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(x => x.ReadModelById(It.IsAny<int>())).ReturnsAsync(default(CostCalculationGarment));
            var controller = GetController(mocks);
            var response = controller.GetPDF(1).Result;

            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);

        }

        //[Fact]
        //public void Get_PDF_Exception()
        //{
        //    var mocks = GetMocks();
        //    mocks.Facade.Setup(x => x.ReadByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception("error"));
        //    var controller = GetController(mocks);
        //    var response = controller.GetPDF(1).Result;

        //    int statusCode = this.GetStatusCode(response);
        //    Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);

        //}

        [Fact]
        public void Get_PDF_Local_OK()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                //Comodity = new MasterPlanComodityViewModel(),
                //Unit = new UnitViewModel(),
                Rate = new RateViewModel(),
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                //BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel()
            };

            mocks.Facade.Setup(x => x.ReadModelById(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = controller.GetPDF(1).Result;

            Assert.NotNull(response);

        }

        [Fact]
        public void Get_Budget_OK()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                //Comodity = new MasterPlanComodityViewModel(),
                //Unit = new UnitViewModel(),
                Rate = new RateViewModel()
                {
                    Value = 1
                },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                //BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ConfirmPrice = 1,
                ConfirmDate = DateTimeOffset.UtcNow
            };

            mocks.Facade.Setup(x => x.ReadModelById(It.IsAny<int>())).ReturnsAsync(Model);
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = controller.GetBudget(1).Result;

            Assert.NotNull(response);

        }

        [Fact]
        public void Get_Budget_InternalServerError()
        {
            var mocks = GetMocks();

            var viewModel = new CostCalculationGarmentViewModel()
            {
                //Comodity = new MasterPlanComodityViewModel(),
                //Unit = new UnitViewModel(),
                Rate = new RateViewModel()
                {
                    Value = 1
                },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>()
                {
                    new CostCalculationGarment_MaterialViewModel()
                    {
                        Category = new CategoryViewModel(),
                        Product = new GarmentProductViewModel(),
                        UOMQuantity = new UOMViewModel(),
                        UOMPrice = new UOMViewModel()
                    }
                },
                UOM = new UOMViewModel(),
                Buyer = new BuyerViewModel(),
                //BuyerBrand = new BuyerBrandViewModel(),
                DeliveryDate = DateTimeOffset.UtcNow,
                OTL1 = new RateCalculatedViewModel(),
                OTL2 = new RateCalculatedViewModel(),
                ConfirmPrice = 1,
                ConfirmDate = DateTimeOffset.UtcNow
            };

            mocks.Facade.Setup(x => x.ReadModelById(It.IsAny<int>())).ThrowsAsync(new Exception());
            mocks.Mapper.Setup(f => f.Map<CostCalculationGarmentViewModel>(It.IsAny<CostCalculationGarment>())).Returns(viewModel);

            var controller = GetController(mocks);
            var response = controller.GetBudget(1).Result;

            var statusCode = GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);

        }
    }
}
