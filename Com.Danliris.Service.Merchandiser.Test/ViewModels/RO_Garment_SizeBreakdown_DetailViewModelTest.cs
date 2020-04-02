using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
   public class RO_Garment_SizeBreakdown_DetailViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_RO_Garment_SizeBreakdown_DetailViewModel()
        {
            string Code = "Code Test";
            string Information = "Information Test";
            string Size = "Size test";
            int Quantity = 1;

            var result = new RO_Garment_SizeBreakdown_DetailViewModel();
            result.Code = Code;
            result.Information = Information;
            result.Size = Size;
            result.Quantity = Quantity;

            Assert.Equal(Code, result.Code);
            Assert.Equal(Information, result.Information);
            Assert.Equal(Size, result.Size);
            Assert.Equal(Quantity, result.Quantity);

        }
    }
}
