using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
    public class CostCalculationGarment_MaterialTest
    {
        [Fact]
        public void Should_Success_Instantiate_CostCalculationGarment_Material()
        {
            int CostCalculationGarmentId = 1;
            string Code = "Code test";
            string PO_SerialNumber = "PO_SerialNumber";
            string Convection = "Convection";
            string PO = "PO test";
            string CategoryId = "CategoryId";
            string CategoryName = "CategoryName test";
            int AutoIncrementNumber = 1;
            string ProductId = "ProductId test";
            string ProductCode = "ProductCode test";
            string Composition = "Composition test";
            string Construction = "Construction test";
            string Yarn = "Yarn test";
            string Width = "Width test";
            string Description = "Description test";
            double Quantity = 1.0;
            string UOMQuantityId = "UOMQuantityId test";
            string UOMQuantityName = "UOMQuantityName test";
            double Price = 1.0;
            string UOMPriceId = "UOMPriceId test test";
            string UOMPriceName = "UOMPriceName test";
            double Conversion = 1.0;
            double Total = 1.0;
            bool isFabricCM = true;
            double CM_Price = 1.0;
            double ShippingFeePortion = 1.0;
            double TotalShippingFee = 1.0;
            double BudgetQuantity = 1.0;
            string Information = "Information test";
            CostCalculationGarment CostCalculationGarment = new CostCalculationGarment();

            CostCalculationGarment_Material cgm = new CostCalculationGarment_Material()
            {
                CostCalculationGarmentId = CostCalculationGarmentId,
                CostCalculationGarment = CostCalculationGarment,
                Code = Code,
                PO_SerialNumber = PO_SerialNumber,
                Convection = Convection,
                PO = PO,
                CategoryId = CategoryId,
                CategoryName = CategoryName,
                AutoIncrementNumber = AutoIncrementNumber,
                ProductId = ProductId,
                ProductCode = ProductCode,
                Composition = Composition,
                Construction = Construction,
                Yarn = Yarn,
                Width = Width,
                Description = Description,
                Quantity = Quantity,
                UOMQuantityId = UOMQuantityId,
                UOMQuantityName = UOMQuantityName,
                Price = Price,
                UOMPriceId = UOMPriceId,
                UOMPriceName = UOMPriceName,
                Conversion = Conversion,
                Total = Total,
                isFabricCM = isFabricCM,
                CM_Price = CM_Price,
                ShippingFeePortion = ShippingFeePortion,
                TotalShippingFee = TotalShippingFee,
                BudgetQuantity = BudgetQuantity,
                Information = Information,
            };


            Assert.Equal(CostCalculationGarmentId, cgm.CostCalculationGarmentId);
            Assert.Equal(CostCalculationGarment, cgm.CostCalculationGarment);
            Assert.Equal(Code, cgm.Code);
            Assert.Equal(PO_SerialNumber, cgm.PO_SerialNumber);
            Assert.Equal(Convection, cgm.Convection);
            Assert.Equal(PO, cgm.PO);
            Assert.Equal(CategoryId, cgm.CategoryId);
            Assert.Equal(CategoryName, cgm.CategoryName);
            Assert.Equal(CategoryId, cgm.CategoryId);
            Assert.Equal(ProductId, cgm.ProductId);
            Assert.Equal(AutoIncrementNumber, cgm.AutoIncrementNumber);
            Assert.Equal(ProductCode, cgm.ProductCode);
            Assert.Equal(Composition, cgm.Composition);
            Assert.Equal(Construction, cgm.Construction);
            Assert.Equal(Yarn, cgm.Yarn);
            Assert.Equal(Width, cgm.Width);
            Assert.Equal(Description, cgm.Description);
            Assert.Equal(Quantity, cgm.Quantity);
            Assert.Equal(UOMQuantityId, cgm.UOMQuantityId);
            Assert.Equal(UOMQuantityName, cgm.UOMQuantityName);
            Assert.Equal(Price, cgm.Price);
            Assert.Equal(UOMPriceId, cgm.UOMPriceId);
            Assert.Equal(UOMPriceName, cgm.UOMPriceName);
            Assert.Equal(Conversion, cgm.Conversion);
            Assert.Equal(Total, cgm.Total);
            Assert.Equal(isFabricCM, cgm.isFabricCM);
            Assert.Equal(CM_Price, cgm.CM_Price);
            Assert.Equal(ShippingFeePortion, cgm.ShippingFeePortion);
            Assert.Equal(TotalShippingFee, cgm.TotalShippingFee);
            Assert.Equal(BudgetQuantity, cgm.BudgetQuantity);
            Assert.Equal(Information, cgm.Information);

        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            CostCalculationGarment_Material ccgm = new CostCalculationGarment_Material();
            var defaultValidationResult = ccgm.Validate(null);
            Assert.True(defaultValidationResult.Count() == 0);
        }
    }
}
