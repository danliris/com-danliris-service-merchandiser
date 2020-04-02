using Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.WebApi.Controllers
{
    public class DefaultControllerTest
    {
        [Fact]
        public void Index_Return_Succses()
        {
            DefaultController dc = new DefaultController();
            var result= dc.Index();
            Assert.NotNull(result);
        }
    }
}
