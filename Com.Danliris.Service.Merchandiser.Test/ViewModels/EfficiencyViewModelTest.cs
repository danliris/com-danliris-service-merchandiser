using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
    public class EfficiencyViewModelTest
    {

        [Fact]
        public void Should_Success_Instantiate_EfficiencyViewModel()
        {
            string Name = "name test";
            string Code = "Code test";
            int InitialRange = 1;
            int FinalRange = 1;
            double Value = 1.0;
            EfficiencyViewModel avm = new EfficiencyViewModel()
            {
                Code = Code,
                Name = Name,
                InitialRange = InitialRange,
                FinalRange= FinalRange,
                Value= Value,
            };

            Assert.Equal(Name, avm.Name);
            Assert.Equal(Code, avm.Code);
            Assert.Equal(InitialRange, avm.InitialRange);
            Assert.Equal(FinalRange, avm.FinalRange);
            Assert.Equal(Value, avm.Value);

        }


        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            EfficiencyViewModel evm = new EfficiencyViewModel();
            var defaultValidationResult = evm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_filled_Return_Success()
        {
            EfficiencyViewModel evm = new EfficiencyViewModel()
            {
                InitialRange = -1,
                FinalRange =-1,
                Value =1,
            };
            var defaultValidationResult = evm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_withSameValueRange_Return_Success()
        {
            EfficiencyViewModel evm = new EfficiencyViewModel()
            {
                InitialRange = 2,
                FinalRange = 2,
                Value = 1,
            };
            var defaultValidationResult = evm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

    }
}
