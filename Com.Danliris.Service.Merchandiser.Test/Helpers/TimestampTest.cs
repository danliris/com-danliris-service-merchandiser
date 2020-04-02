using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
   public class TimestampTest
    {
        [Fact]
        public void Generate_Return_Success()
        {
            DateTime value = new DateTime();
          var result=  Timestamp.Generate(value);

            Assert.NotNull(result);

        }
            
    }
}
