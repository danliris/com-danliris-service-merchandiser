
using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
    public class RO_GarmentTest
    {

        [Fact]
        public void Should_Success_Instantiate_Line()
        {
            int CostCalculationGarmentId = 1;
            CostCalculationGarment CostCalculationGarment = new CostCalculationGarment();
            string Code = "Code test";
            List < RO_Garment_SizeBreakdown > RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>();
            string Instruction = "Instruction test";
            int Total = 1;
            List<string> ImagesFile = new List<string>();
            string ImagesPath = "c://ImagesPath.jpg";
            string ImagesName = "ImagesName.jpg test";
            RO_Garment ac = new RO_Garment()
            {
                CostCalculationGarmentId = CostCalculationGarmentId,
                CostCalculationGarment = CostCalculationGarment,
                Code = Code,
                RO_Garment_SizeBreakdowns = RO_Garment_SizeBreakdowns,
                Instruction = Instruction,
                Total = Total,
                ImagesFile = ImagesFile,
                ImagesPath = ImagesPath,
                ImagesName = ImagesName,
            };

            Assert.Equal(CostCalculationGarmentId, ac.CostCalculationGarmentId);
            Assert.Equal(CostCalculationGarment, ac.CostCalculationGarment);
            Assert.Equal(Code, ac.Code);
            Assert.Equal(RO_Garment_SizeBreakdowns, ac.RO_Garment_SizeBreakdowns);
            Assert.Equal(Instruction, ac.Instruction);
            Assert.Equal(Total, ac.Total);
            Assert.Equal(ImagesFile, ac.ImagesFile);
            Assert.Equal(ImagesPath, ac.ImagesPath);
            Assert.Equal(ImagesName, ac.ImagesName);

        }


        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            RO_Garment defaultViewModel = new RO_Garment();
            Assert.Empty(defaultViewModel.Validate(null));
        }
    }
}
