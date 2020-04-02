using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
  public  class CostCalculationGarmentViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_CostCalculationGarmentViewMode()
        {
            int AutoIncrementNumber = 1;
            double AccessoriesAllowance = 1.0;
            string Article = "Article test";
            BuyerViewModel bvm = new BuyerViewModel();
            double CommissionPortion = 1.0;
            double CommissionRate = 1.0;
            UOMViewModel UOM = new UOMViewModel();
            MasterPlanComodityViewModel Commodity = new MasterPlanComodityViewModel();
            DateTimeOffset ConfirmDate = new DateTimeOffset();
            string CommodityDescription = "CommodityDescription test";
            double ConfirmPrice = 1.0;
            string Convection = "Convection test";
            List<CostCalculationGarment_MaterialViewModel> CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>();
            DateTimeOffset DeliveryDate = new DateTimeOffset();
            string Description = "Description test";
            EfficiencyViewModel Efficiency = new EfficiencyViewModel();
            double FabricAllowance = 1.0;
            double Freight = 1.0;
            double FreightCost = 1.0;
            string ImageFile = "example.jpg";
            double Index = 1.0;
            double Insurance = 1.0;
            int LeadTime = 1;
            string Code = "Code test";
            int RO_GarmentId = 1;
            string RO_Number = "RO_Number test";
            string Section = "Section test";
            int Quantity = 1;
            string SizeRange = "SizeRange test";
            double SMV_Cutting = 1.0;
            double SMV_Sewing = 1.0;
            double SMV_Finishing = 1.0;
            double SMV_Total = 1.0;
            RateViewModel Wage = new RateViewModel();
            RateViewModel THR = new RateViewModel();
            RateViewModel Rate = new RateViewModel();
            RateCalculatedViewModel OTL1 = new RateCalculatedViewModel();
            RateCalculatedViewModel OTL2 = new RateCalculatedViewModel();
            double Risk = 1.0;
            double ProductionCost = 1.0;
            double NETFOB = 1.0;
            double NETFOBP = 1.0;
            string ImagePath = "C:\\Users\\example.jpg";
            int RO_RetailId = 1;

            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel()
            {
                AutoIncrementNumber = AutoIncrementNumber,
                AccessoriesAllowance = AccessoriesAllowance,
                Article = Article,
                Buyer = bvm,
                CommissionPortion = CommissionPortion,
                CommissionRate = CommissionRate,
                UOM = UOM,
                ConfirmDate = ConfirmDate,
                CommodityDescription = CommodityDescription,
                Commodity = Commodity,
                ConfirmPrice = ConfirmPrice,
                Convection = Convection,
                CostCalculationGarment_Materials = CostCalculationGarment_Materials,
                DeliveryDate = DeliveryDate,
                Description = Description,
                Efficiency = Efficiency,
                FabricAllowance = FabricAllowance,
                Freight = Freight,
                FreightCost = FreightCost,
                ImageFile = ImageFile,
                Index = Index,
                Insurance = Insurance,
                LeadTime = LeadTime,
                Code = Code,
                RO_GarmentId = RO_GarmentId,
                RO_Number = RO_Number,
                Section = Section,
                Quantity = Quantity,
                SizeRange = SizeRange,
                SMV_Cutting = SMV_Cutting,
                SMV_Sewing = SMV_Sewing,
                SMV_Finishing = SMV_Finishing,
                SMV_Total = SMV_Total,
                Wage = Wage,
                THR = THR,
                Rate = Rate,
                OTL1 = OTL1,
                OTL2 = OTL2,
                Risk = Risk,
                ProductionCost = ProductionCost,
                NETFOB= NETFOB,
                NETFOBP = NETFOBP ,
                ImagePath= ImagePath,
                RO_RetailId = RO_RetailId,
            };
            Assert.Equal(AutoIncrementNumber, ccgvm.AutoIncrementNumber);
            Assert.Equal(AccessoriesAllowance, ccgvm.AccessoriesAllowance);
            Assert.Equal(Article, ccgvm.Article);
            Assert.Equal(bvm, ccgvm.Buyer);
            Assert.Equal(CommissionPortion, ccgvm.CommissionPortion);
            Assert.Equal(CommissionRate, ccgvm.CommissionRate);
            Assert.Equal(UOM, ccgvm.UOM);
            Assert.Equal(Commodity, ccgvm.Commodity);
            Assert.Equal(ConfirmDate, ccgvm.ConfirmDate);
            Assert.Equal(CommodityDescription, ccgvm.CommodityDescription);
            Assert.Equal(ConfirmPrice, ccgvm.ConfirmPrice);
            Assert.Equal(Convection, ccgvm.Convection);
            Assert.Equal(CostCalculationGarment_Materials, ccgvm.CostCalculationGarment_Materials);
            Assert.Equal(DeliveryDate, ccgvm.DeliveryDate);
            Assert.Equal(Description, ccgvm.Description);
            Assert.Equal(FabricAllowance, ccgvm.FabricAllowance);
            Assert.Equal(Freight, ccgvm.Freight);
            Assert.Equal(Efficiency, ccgvm.Efficiency);
            Assert.Equal(FreightCost, ccgvm.FreightCost);
            Assert.Equal(ImageFile, ccgvm.ImageFile);
            Assert.Equal(Index, ccgvm.Index);
            Assert.Equal(Insurance, ccgvm.Insurance);
            Assert.Equal(LeadTime, ccgvm.LeadTime);
            Assert.Equal(Code, ccgvm.Code);
            Assert.Equal(RO_GarmentId, ccgvm.RO_GarmentId);
            Assert.Equal(RO_Number, ccgvm.RO_Number);
            Assert.Equal(Section, ccgvm.Section);
            Assert.Equal(Quantity, ccgvm.Quantity);
            Assert.Equal(SizeRange, ccgvm.SizeRange);
            Assert.Equal(SMV_Cutting, ccgvm.SMV_Cutting);
            Assert.Equal(SMV_Sewing, ccgvm.SMV_Sewing);
            Assert.Equal(SMV_Finishing, ccgvm.SMV_Finishing);
            Assert.Equal(SMV_Total, ccgvm.SMV_Total);
            Assert.Equal(Wage, ccgvm.Wage);
            Assert.Equal(THR, ccgvm.THR);
            Assert.Equal(Rate, ccgvm.Rate);
            Assert.Equal(OTL1, ccgvm.OTL1);
            Assert.Equal(OTL2, ccgvm.OTL2);
            Assert.Equal(Risk, ccgvm.Risk);
            Assert.Equal(ProductionCost, ccgvm.ProductionCost);
            Assert.Equal(NETFOB, ccgvm.NETFOB);
            Assert.Equal(NETFOBP, ccgvm.NETFOBP);
            Assert.Equal(ImagePath, ccgvm.ImagePath);
            Assert.Equal(RO_RetailId, ccgvm.RO_RetailId);
        }


        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel();
            var defaultValidationResult = ccgvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }


        [Fact]
        public void Validate_withFilledZeroProps_Return_Success()
        {
            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel()
            {
                FabricAllowance = 0,
                AccessoriesAllowance = 0,
                Quantity = 0,
                SMV_Cutting = 0,
                SMV_Sewing = 0,
                SMV_Finishing = 0,
                ConfirmPrice = 0,
                DeliveryDate = DateTimeOffset.Now,
                Efficiency = new EfficiencyViewModel() { Id = 0 },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>() { new CostCalculationGarment_MaterialViewModel() { Category = new CategoryViewModel() { code = "code test",_id ="id test" } } }
             
            };
            var defaultValidationResult = ccgvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }


        [Fact]
        public void Validate_FilledCostCalculation_Material_Return_Success()
        {
            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel()
            {

                Efficiency = new EfficiencyViewModel() { Id = 0 },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>() { new CostCalculationGarment_MaterialViewModel() {
                    Category = new CategoryViewModel() { code = "code test", _id = "id test" },
                    Quantity =1 ,
                    Conversion =1.0,
                    UOMQuantity = new UOMViewModel(),
                    UOMPrice = new UOMViewModel(),
                } }

            };
            var defaultValidationResult = ccgvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }


        [Fact]
        public void Validate_FilledInvalidValueCostCalculation_Material_Return_Success()
        {
            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel()
            {

                Efficiency = new EfficiencyViewModel() { Id = 0 },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>() { new CostCalculationGarment_MaterialViewModel() {
                    Category = new CategoryViewModel() { code = "code test", _id = "id test" },
                    Quantity = -1 ,
                    Conversion = -1.0,
                } }

            };
            var defaultValidationResult = ccgvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_withNUllCategoryCostCalculation_Material_Return_Success()
        {
            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel()
            {

                Efficiency = new EfficiencyViewModel() { Id = 0 },
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>() { new CostCalculationGarment_MaterialViewModel() {
                    Category = new CategoryViewModel() { code = "code test", _id = null },
                  
                } }

            };
            var defaultValidationResult = ccgvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_withNullEfficiency_Return_Success()
        {
            CostCalculationGarmentViewModel ccgvm = new CostCalculationGarmentViewModel()
            {
                Quantity = 1,
                Efficiency = new EfficiencyViewModel() { Id = 0 },
            };
            var defaultValidationResult = ccgvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

    }
}
