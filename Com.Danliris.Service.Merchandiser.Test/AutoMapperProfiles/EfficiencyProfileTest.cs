using Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.AutoMapperProfiles
{
    public class EfficiencyProfileTest
    {
        [Fact]
        public void should_Succes_Instantiate_EfficiencyProfile()
        {
            EfficiencyProfile ef = new EfficiencyProfile();
        }
    }
}
