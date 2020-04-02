using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
  public   class CostCalculationGarment_MaterialViewModelTest
    {
        [Fact]
        public void Should_Success_CostCalculationGarment_MaterialViewModel()
        {
            var cg_mvm = new CostCalculationGarment_MaterialViewModel();
            string Code = "code test";
            string PO_SerialNumber = "PO_SerialNumber test";
            string PO = "PO test";
            CategoryViewModel Category = new CategoryViewModel();
            int AutoIncrementNumber = 1;
            GarmentProductViewModel Product = new GarmentProductViewModel();
            string Description = "Description test";
            double Quantity = 2.0;
            UOMViewModel UOMQuantity = new UOMViewModel();
            double Price = 3.0;
            UOMViewModel UOMPrice = new UOMViewModel();
            double Conversion = 4.0;
            double Total = 5.0;
            bool isFabricCM = true;
            double CM_Price = 6.0;
            double ShippingFeePortion = 6.0;
            double TotalShippingFee = 7.0;
            double BudgetQuantity = 8.0;
            string Information = "information test";
            string Convection = "Convection test";

            cg_mvm.Code = Code;
            cg_mvm.PO_SerialNumber = PO_SerialNumber;
            cg_mvm.PO = PO;
            cg_mvm.Category = Category;
            cg_mvm.AutoIncrementNumber = AutoIncrementNumber;
            cg_mvm.Product = Product;
            cg_mvm.Description = Description;
            cg_mvm.Quantity = Quantity;
            cg_mvm.UOMQuantity = UOMQuantity;
            cg_mvm.Price = Price;
            cg_mvm.UOMPrice = UOMPrice;
            cg_mvm.Conversion = Conversion;
            cg_mvm.Total = Total;
            cg_mvm.isFabricCM = isFabricCM;
            cg_mvm.CM_Price = CM_Price;
            cg_mvm.ShippingFeePortion = ShippingFeePortion;
            cg_mvm.TotalShippingFee = TotalShippingFee;
            cg_mvm.BudgetQuantity = BudgetQuantity;
            cg_mvm.Information = Information;
            cg_mvm.Convection = Convection;

            Assert.Equal(Code,cg_mvm.Code);
            Assert.Equal(PO_SerialNumber, cg_mvm.PO_SerialNumber);
            Assert.Equal(PO, cg_mvm.PO);
            Assert.Equal(Category, cg_mvm.Category);
            Assert.Equal(AutoIncrementNumber, cg_mvm.AutoIncrementNumber);
            Assert.Equal(Product, cg_mvm.Product);
            Assert.Equal(Description, cg_mvm.Description);
            Assert.Equal(Quantity, cg_mvm.Quantity);
            Assert.Equal(UOMQuantity, cg_mvm.UOMQuantity);
            Assert.Equal(Price, cg_mvm.Price);
            Assert.Equal(UOMPrice, cg_mvm.UOMPrice);
            Assert.Equal(Conversion, cg_mvm.Conversion);
            Assert.Equal(Total, cg_mvm.Total);
            Assert.Equal(isFabricCM, cg_mvm.isFabricCM);
            Assert.Equal(CM_Price, cg_mvm.CM_Price);
            Assert.Equal(ShippingFeePortion, cg_mvm.ShippingFeePortion);
            Assert.Equal(TotalShippingFee, cg_mvm.TotalShippingFee);
            Assert.Equal(BudgetQuantity, cg_mvm.BudgetQuantity);
            Assert.Equal(Information, cg_mvm.Information);
            Assert.Equal(Convection, cg_mvm.Convection);

        }
    }
}
