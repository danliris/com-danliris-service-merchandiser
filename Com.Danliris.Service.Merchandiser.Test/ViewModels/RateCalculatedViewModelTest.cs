using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
  public  class RateCalculatedViewModelTest
    {
        [Fact]
       public void Should_Success_Instantiate_RateCalculatedViewModel()
        {
            double CalculatedValue = 1;
            var rcvm = new RateCalculatedViewModel();
            rcvm.CalculatedValue = CalculatedValue;
            Assert.Equal(CalculatedValue, rcvm.CalculatedValue);
        }
    }
}
