using Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.AutoMapperProfiles
{
   public class CostCalculationGarment_MaterialProfileTest
    {
        [Fact]
       public void ShouldSuccessInstantiateCostCalculationGarment_MaterialProfile()
        {
            CostCalculationGarment_MaterialProfile obj = new CostCalculationGarment_MaterialProfile();
        }
    }
}
