using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
  public  class MasterPlanComodityViewModelTest
    {
        [Fact]
        public void Should_Success_Insatantiate_MasterPlanComodityViewModel()
        {
            string name = "name test";
            string code = "code test";
            var mpvm =new  MasterPlanComodityViewModel();
            mpvm.name = name;
            mpvm.code = code;

            Assert.Equal(name, mpvm.name);
            Assert.Equal(code, mpvm.code);
        }
    }
}
