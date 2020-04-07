using Com.Danliris.Service.Merchandiser.Lib.PdfTemplates;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.PdfTemplates
{
    public class CostCalculationGarmentBudgetPdfTemplateTest
    {

        [Fact]
        public void GeneratePdfTemplate_Return_Success()
        {
            CostCalculationGarmentViewModel viewmodel = new CostCalculationGarmentViewModel()
            {
                Rate = new RateViewModel() { Id = 1, Value = 2.0 },
                Buyer = new BuyerViewModel() { name = "buyer name" },
                ConfirmPrice = 10,
                CostCalculationGarment_Materials = new List<CostCalculationGarment_MaterialViewModel>() { 
                    new CostCalculationGarment_MaterialViewModel() { 
                        TotalShippingFee= 1 ,
                        Category= new CategoryViewModel(){name="FABRIC" },
                    Product = new GarmentProductViewModel(){},
                    UOMQuantity = new UOMViewModel(){},
                    UOMPrice = new UOMViewModel(){unit = "3"}
                    } 

                   
                },


            };

            CostCalculationGarmentBudgetPdfTemplate pdfTemplate = new CostCalculationGarmentBudgetPdfTemplate();
            var result = pdfTemplate.GeneratePdfTemplate(viewmodel, 5);
            Assert.NotNull(result);

        }
    }
}
