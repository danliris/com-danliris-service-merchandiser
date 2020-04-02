using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
    public class CostCalculationGarmentTest
    {
        [Fact]
        public void Should_Success_Instantiate_ArticleColorTest()
        {
            string Code = "Code test";
            string RO_Number = "RO_Number test";
            string RO = "RO test";
            string Article = "Article test";
            string ComodityID = "ComodityID test";
            string Commodity = "Commodity test";
            string CommodityDescription = "CommodityDescription test";
            double FabricAllowance = 1.0;
            double AccessoriesAllowance =1.0;
            string Section = "Section test";
            string UOMID = "UOMID test";
            string UOMCode = "UOMCode test";

            string UOMUnit = "UOMUnit test";
            int Quantity = 1;
            string SizeRange = "SizeRange test";
            DateTimeOffset DeliveryDate = new DateTimeOffset();
            DateTimeOffset ConfirmDate = new DateTimeOffset();
            int LeadTime = 1;
            double SMV_Cutting = 1.0;
            double SMV_Sewing = 1.0;
            double SMV_Finishing = 1.0;
            double SMV_Total = 1.0;
            string BuyerId = "BuyerId test";
            string BuyerName = "BuyerName test";
            long EfficiencyId = 1;
            double EfficiencyValue = 1.0;
            double Index = 1.0;
            long WageId = 1;
            double WageRate = 1.0;
            long THRId = 1;
            double THRRate = 1.0;
            double ConfirmPrice = 1.0;
            long RateId = 1;
            double RateValue = 1.0;
           


            List<CostCalculationGarment_Material> CostCalculationGarment_Materials = new List<CostCalculationGarment_Material>{
            //new CostCalculationGarment_Material()
            };
            double Freight = 1.0;
            double Insurance = 1.0;
            double CommissionPortion = 1.0;
            double CommissionRate = 1.0;
            long OTL1Id = 1;
            double OTL1Rate = 1.0;
            double OTL1CalculatedRate = 1.0;
            long OTL2Id = 1;
            double OTL2Rate = 1.0;
            double OTL2CalculatedRate = 1.0;
            double Risk = 1.0;
            double ProductionCost = 1.0;
            double NETFOB = 1.0;
            double FreightCost = 1.0;
            double NETFOBP = 1.0;
            string Description = "Description test";
            string ImageFile = "ImageFile.jpg";
            string ImagePath = "c://ImagePath.jpg";
            int RO_GarmentId = 1;
            string Convection = "Convection test";
            int AutoIncrementNumber = 1;
            RO_Garment RO_Garment = new RO_Garment();

            CostCalculationGarment ccg = new CostCalculationGarment()
            {
                Code = Code,
                RO_Number = RO_Number,
                RO = RO,
                Article = Article,
                ComodityID = ComodityID,
                Commodity = Commodity,
                CommodityDescription = CommodityDescription,
                FabricAllowance = FabricAllowance,
                AccessoriesAllowance = AccessoriesAllowance,
                Section = Section,
                UOMID = UOMID,
                UOMCode = UOMCode,
                UOMUnit = UOMUnit,
                Quantity = Quantity,
                SizeRange = SizeRange,
                DeliveryDate = DeliveryDate,
                ConfirmDate = ConfirmDate,
                LeadTime = LeadTime,
                SMV_Cutting = SMV_Cutting,
                SMV_Sewing = SMV_Sewing,
                SMV_Finishing = SMV_Finishing,
                SMV_Total = SMV_Total,
                BuyerId = BuyerId,
                BuyerName = BuyerName,
                EfficiencyId = EfficiencyId,
                EfficiencyValue = EfficiencyValue,
                Index = Index,
                WageId = WageId,
                WageRate = WageRate,
                THRId = THRId,
                THRRate = THRRate,
                ConfirmPrice = ConfirmPrice,
                RateId = RateId,
                RateValue = RateValue,
                CostCalculationGarment_Materials = CostCalculationGarment_Materials,
                Freight = Freight,
                Insurance = Insurance,
                CommissionPortion = CommissionPortion,
                CommissionRate = CommissionRate,
                OTL1Id = OTL1Id,
                OTL1Rate = OTL1Rate,
                OTL1CalculatedRate = OTL1CalculatedRate,
                OTL2Id = OTL2Id,
                OTL2Rate = OTL2Rate,
                OTL2CalculatedRate = OTL2CalculatedRate,
                Risk = Risk,
                ProductionCost = ProductionCost,
                NETFOB = NETFOB,
                FreightCost = FreightCost,
                NETFOBP= NETFOBP,
                Description = Description,
                ImageFile= ImageFile,
                ImagePath = ImagePath,
                RO_GarmentId = RO_GarmentId,
                Convection = Convection,
                AutoIncrementNumber = AutoIncrementNumber,
                RO_Garment = RO_Garment,
            };

            Assert.Equal(Code, ccg.Code);
            Assert.Equal(RO_Number, ccg.RO_Number);
            Assert.Equal(RO, ccg.RO);
            Assert.Equal(Article, ccg.Article);
            Assert.Equal(ComodityID, ccg.ComodityID);
            Assert.Equal(Commodity, ccg.Commodity);
            Assert.Equal(CommodityDescription, ccg.CommodityDescription);
            Assert.Equal(FabricAllowance, ccg.FabricAllowance);
            Assert.Equal(AccessoriesAllowance, ccg.AccessoriesAllowance);
            Assert.Equal(Section, ccg.Section);
            Assert.Equal(UOMID, ccg.UOMID);
            Assert.Equal(UOMCode, ccg.UOMCode);
            Assert.Equal(UOMUnit, ccg.UOMUnit);
            Assert.Equal(Quantity, ccg.Quantity);
            Assert.Equal(SizeRange, ccg.SizeRange);
            Assert.Equal(DeliveryDate, ccg.DeliveryDate);
            Assert.Equal(ConfirmDate, ccg.ConfirmDate);
            Assert.Equal(LeadTime, ccg.LeadTime);
            Assert.Equal(SMV_Cutting, ccg.SMV_Cutting);
            Assert.Equal(SMV_Sewing, ccg.SMV_Sewing);
            Assert.Equal(SMV_Finishing, ccg.SMV_Finishing);
            Assert.Equal(SMV_Total, ccg.SMV_Total);
            Assert.Equal(BuyerId, ccg.BuyerId);
            Assert.Equal(BuyerName, ccg.BuyerName);
            Assert.Equal(EfficiencyId, ccg.EfficiencyId);
            Assert.Equal(EfficiencyValue, ccg.EfficiencyValue);
            Assert.Equal(Index, ccg.Index);
            Assert.Equal(WageId, ccg.WageId);
            Assert.Equal(WageRate, ccg.WageRate);
            Assert.Equal(THRId, ccg.THRId);
            Assert.Equal(THRRate, ccg.THRRate);
            Assert.Equal(ConfirmPrice, ccg.ConfirmPrice);
            Assert.Equal(RateId, ccg.RateId);
            Assert.Equal(RateValue, ccg.RateValue);
            Assert.Equal(CostCalculationGarment_Materials, ccg.CostCalculationGarment_Materials);
            Assert.Equal(Freight, ccg.Freight);
            Assert.Equal(Insurance, ccg.Insurance);
            Assert.Equal(CommissionPortion, ccg.CommissionPortion);
            Assert.Equal(CommissionRate, ccg.CommissionRate);
            Assert.Equal(OTL1Id, ccg.OTL1Id);
            Assert.Equal(OTL1Rate, ccg.OTL1Rate);
            Assert.Equal(OTL1CalculatedRate, ccg.OTL1CalculatedRate);
            Assert.Equal(OTL2Id, ccg.OTL2Id);
            Assert.Equal(OTL2Rate, ccg.OTL2Rate);
            Assert.Equal(OTL2CalculatedRate, ccg.OTL2CalculatedRate);
            Assert.Equal(Risk, ccg.Risk);
            Assert.Equal(ProductionCost, ccg.ProductionCost);
            Assert.Equal(NETFOB, ccg.NETFOB);
            Assert.Equal(FreightCost, ccg.FreightCost);
            Assert.Equal(NETFOBP, ccg.NETFOBP);
            Assert.Equal(Description, ccg.Description);
            Assert.Equal(ImageFile, ccg.ImageFile);
            Assert.Equal(ImagePath, ccg.ImagePath);
            Assert.Equal(RO_GarmentId, ccg.RO_GarmentId);
            Assert.Equal(Convection, ccg.Convection);
            Assert.Equal(AutoIncrementNumber, ccg.AutoIncrementNumber);
            Assert.Equal(RO_Garment, ccg.RO_Garment);

        }

        [Fact]
        public void Validate_Return_Exception()
        {
            CostCalculationGarment defaultViewModel = new CostCalculationGarment();
            Assert.Throws<NotImplementedException>(() => defaultViewModel.Validate(null));
        }
    }
}
