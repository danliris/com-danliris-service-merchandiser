using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
   public class EfficiencyTest
    {
        [Fact]
        public void Should_Success_Instantiate_EfficiencyTest()
        {
            string Code = "Code test";
            string Name = "Name test";
            int InitialRange = 1;
            int FinalRange = 1;
            double Value = 1.0;
            Efficiency ac = new Efficiency()
            {
                Code = Code,
                Name = Name,
                InitialRange = InitialRange,
                FinalRange = FinalRange,
                Value = Value,
            };

            Assert.Equal(Code, ac.Code);
            Assert.Equal(Name, ac.Name);
            Assert.Equal(InitialRange, ac.InitialRange);
            Assert.Equal(FinalRange, ac.FinalRange);
            Assert.Equal(Value, ac.Value);
            
        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            Efficiency ac = new Efficiency();
            var defaultValidationResult = ac.Validate(null);
            Assert.True(defaultValidationResult.Count() == 0);
        }
    }
}
