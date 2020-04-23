using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
  public  class NumberTest
    {
        [Fact]
        public void ToRupiah_when_Input_String_Return_Success()
        {

            dynamic number = "200";
            var result = Number.ToRupiah(number);
            Assert.NotNull(result);
            Assert.Equal("200",result);

        }

        [Fact]
        public void ToRupiah_When_Input_Number_Return_Success()
        {
            dynamic number = 200;
            var result = Number.ToRupiah(number);
            Assert.NotNull(result);
            Assert.Equal("Rp200,00", result);

        }

        [Fact]
        public void ToRupiahWithoutSymbol_when_Input_number_Return_Success()
        {
            dynamic number = 200;
            var result = Number.ToRupiahWithoutSymbol(number);
            Assert.NotNull(result);
            Assert.Equal("200", result);

        }

        [Fact]
        public void ToRupiahWithoutSymbol_when_input_String_Return_Success()
        {
            dynamic number = "200";
            var result = Number.ToRupiahWithoutSymbol(number);
            Assert.NotNull(result);
            Assert.Equal("200", result);

        }


        [Fact]
        public void ToDollar_with_Number_Return_Success()
        {
            dynamic number = 200;
            var result = Number.ToDollar(number);
            Assert.NotNull(result);
            Assert.Equal("$200.00", result);

        }

        [Fact]
        public void ToDollar_with_String_Return_Success()
        {
            dynamic number = "200";
            var result = Number.ToDollar(number);
            Assert.NotNull(result);
            Assert.Equal("200", result);

        }
    }
}
