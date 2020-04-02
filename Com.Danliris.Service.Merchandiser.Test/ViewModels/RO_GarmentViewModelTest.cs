using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
  public  class RO_GarmentViewModelTest
    {
        [Fact]
        public  void Should_Success_Intantiate_RO_GarmentViewModel()
        {
            string Code = "Code test";
            string Instruction = "Instruction test";
            int Total = 1;

            RO_GarmentViewModel rogvm = new RO_GarmentViewModel()
            {
                Code = Code,
                Instruction = Instruction,
                Total = Total,
                ImagesFile = new List<string>() { "ImagesFile test" },
                ImagesPath = new List<string>() { "ImagesPath test" },
                ImagesName = new List<string>() { "ImagesName test" },
                DocumentsFile = new List<string>() { "DocumentsFile test" },
                DocumentsFileName = new List<string>() { "DocumentsFileName test" },
                DocumentsPath = new List<string>() { "DocumentsPath test" },
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdownViewModel>() { new RO_Garment_SizeBreakdownViewModel() }
            };

            Assert.Equal(Code, rogvm.Code);
            Assert.Equal(Instruction, rogvm.Instruction);
            Assert.Equal(Total, rogvm.Total);
            Assert.Equal("ImagesFile test", rogvm.ImagesFile[0]);
            Assert.Equal("ImagesPath test", rogvm.ImagesPath[0]);
            Assert.Equal("ImagesName test", rogvm.ImagesName[0]);
            Assert.Equal("DocumentsFile test", rogvm.DocumentsFile[0]);
            Assert.Equal("DocumentsFileName test", rogvm.DocumentsFileName[0]);
            Assert.Equal("DocumentsPath test", rogvm.DocumentsPath[0]);
           
        }

        [Fact]
        public void Validate_deafult()
        {
            RO_GarmentViewModel rogvm = new RO_GarmentViewModel() {
            RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdownViewModel>() { }
            };
            var defaultValidationResult = rogvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }


        [Fact]
        public void Validate_filled()
        {
           
            RO_GarmentViewModel rogvm = new RO_GarmentViewModel()
            {
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdownViewModel>() { new RO_Garment_SizeBreakdownViewModel() }
            };
            var defaultValidationResult = rogvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
