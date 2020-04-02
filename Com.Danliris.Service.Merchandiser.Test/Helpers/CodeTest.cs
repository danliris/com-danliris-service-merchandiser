using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
   public class CodeTest
    {
        [Fact]
        public void Generate_Return_Success()
        {
            var result = Code.Generate();
            Assert.NotNull( result);
            Assert.Equal(8, result.Length);
        }
    }
}
