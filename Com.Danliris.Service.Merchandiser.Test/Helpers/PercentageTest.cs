using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
   public class PercentageTest
    {
        [Fact]
        public void ToFraction_Return_Succcess()
        {
            dynamic number = "100";
            var result = Percentage.ToFraction(number);
            Assert.NotNull(result);
        }

        [Fact]
        public void ToPercent_Return_Succcess()
        {
            dynamic number = "100";
            var result = Percentage.ToPercent(number);
            Assert.NotNull(result);

        }
        
    }
}
