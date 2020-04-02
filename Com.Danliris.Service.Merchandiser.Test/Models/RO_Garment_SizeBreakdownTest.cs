using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
    public class RO_Garment_SizeBreakdownTest
    {

        [Fact]
        public void Should_Success_Instantiate_RO_Garment_SizeBreakdown()
        {
             int RO_GarmentId = 1;
            RO_Garment RO_Garment = new RO_Garment();
            string Code = "Code test";
            long ColorId = 1;
            string ColorName = "red";
            List<RO_Garment_SizeBreakdown_Detail> RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>();
            int Total = 1;
            RO_Garment_SizeBreakdown ro_gs = new RO_Garment_SizeBreakdown()
            {
                RO_GarmentId = RO_GarmentId,
                RO_Garment = RO_Garment,
                Code = Code,
                ColorId = ColorId,
                ColorName = ColorName,
                RO_Garment_SizeBreakdown_Details = RO_Garment_SizeBreakdown_Details,
                Total = Total,
            };

            Assert.Equal(RO_GarmentId, ro_gs.RO_GarmentId);
            Assert.Equal(RO_Garment, ro_gs.RO_Garment);
            Assert.Equal(Code, ro_gs.Code);
            Assert.Equal(ColorId, ro_gs.ColorId);
            Assert.Equal(ColorName, ro_gs.ColorName);
            Assert.Equal(RO_Garment_SizeBreakdown_Details, ro_gs.RO_Garment_SizeBreakdown_Details);
            Assert.Equal(Total, ro_gs.Total);

        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            RO_Garment_SizeBreakdown ac = new RO_Garment_SizeBreakdown();
            var defaultValidationResult = ac.Validate(null);
            Assert.True(defaultValidationResult.Count() == 0);
        }

    }
}
