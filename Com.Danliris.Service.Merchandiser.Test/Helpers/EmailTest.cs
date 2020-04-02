using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
  public  class EmailTest
    {
        [Fact]
        public void IsValid_Return_Success()
        {
            string email = "danrilis@moonlay.com";
            var result = Email.IsValid(email);
            Assert.True(result);
        }

        [Fact]
        public void IsValid_Return_Fail()
        {
            string email = null;
            var result = Email.IsValid(email);
            Assert.False(result);
        }
    }
}
