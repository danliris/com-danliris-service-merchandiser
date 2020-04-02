using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
    public class UOMViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_UOMviewModel()
        {
            string code = "code test";
            string unit = "unit test";
            UOMViewModel uomvm = new UOMViewModel()
            {
                code = code ,
                unit = unit

            };

            Assert.Equal(code, uomvm.code);
            Assert.Equal(unit, uomvm.unit);
           
        }

        [Fact]
        public void Validate_deafult()
        {
            UOMViewModel uomvm = new UOMViewModel();
            var defaultValidationResult = uomvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_filled()
        {
            string code = "code test";
            string unit = "1";
            UOMViewModel uomvm = new UOMViewModel()
            {
                code = code,
                unit =unit,
            };
            var defaultValidationResult = uomvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
