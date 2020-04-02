using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
  public  class RO_Garment_SizeBreakdown_DetailTest
    {
        [Fact]
        public void Should_Success_Instantiate_RO_Garment_SizeBreakdown_Detail()
        {
            int RO_Garment_SizeBreakdownId = 1;
            RO_Garment_SizeBreakdown RO_Garment_SizeBreakdown = new RO_Garment_SizeBreakdown();
            string Code = "Code test";
            string Information = "Information test";
            string Size = "Size test";
            int Quantity = 1;
            RO_Garment_SizeBreakdown_Detail ac = new RO_Garment_SizeBreakdown_Detail()
            {
                RO_Garment_SizeBreakdownId = RO_Garment_SizeBreakdownId,
                Code = Code,
                RO_Garment_SizeBreakdown = RO_Garment_SizeBreakdown,
                Information = Information,
                Size = Size,
                Quantity = Quantity,

            };
            
                Assert.Equal(RO_Garment_SizeBreakdownId, ac.RO_Garment_SizeBreakdownId);
            Assert.Equal(Code, ac.Code);
            Assert.Equal(RO_Garment_SizeBreakdown, ac.RO_Garment_SizeBreakdown);
            Assert.Equal(Code, ac.Code);
            Assert.Equal(Information, ac.Information);
            Assert.Equal(Size, ac.Size);
            Assert.Equal(Quantity, ac.Quantity);
        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            RO_Garment_SizeBreakdown_Detail sizeDetail = new RO_Garment_SizeBreakdown_Detail();
            var defaultValidationResult = sizeDetail.Validate(null);
            Assert.True(defaultValidationResult.Count() == 0);
        }
    }
}
