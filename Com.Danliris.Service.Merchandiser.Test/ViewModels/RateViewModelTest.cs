using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
    public class RateViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_RateViewModel()
        {
            string Code = "Code test";
            string Name = "Name test";
            double Value = 1.0;
            RateViewModel rvm = new RateViewModel()
            {
                Code = Code,
                Name = Name,
                Value = Value,

            };

            Assert.Equal(Code, rvm.Code);
            Assert.Equal(Name, rvm.Name);
            Assert.Equal(Value, rvm.Value);
        }
    }
}
