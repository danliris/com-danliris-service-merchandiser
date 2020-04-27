using Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.AutoMapperProfiles
{
   public class RateProfileTest
    {
        [Fact]
        public void Should_Success_Instantiate_RateProfile()
        {
            RateProfile re = new RateProfile();
        }
    }
}
