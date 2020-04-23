using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.WebApi.Utils;
using Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.WebApi.Controllers
{
    public class EfficienciesControllerTest : BasicControllerTest<EfficienciesController, Efficiency, EfficiencyViewModel, IEfficiencies>
    {
        [Fact]
        public async Task Should_Success_GetByQUantity()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(x => x.ReadModelByQuantity(It.IsAny<int>()))
                .ReturnsAsync(Model);
            var controller = GetController(mocks);
            var response = await controller.GetByQuantity(1);
            Assert.Equal((int)HttpStatusCode.OK, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_NotFound_GetByQUantity()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(x => x.ReadModelByQuantity(It.IsAny<int>()))
                .ReturnsAsync(default(Efficiency));
            var controller = GetController(mocks);
           
            var response = await controller.GetByQuantity(1);
            Assert.Equal((int)HttpStatusCode.NotFound, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_InternalServerError_GetByQUantity()
        {
            var mocks = GetMocks();
            mocks.Facade.Setup(x => x.ReadModelByQuantity(It.IsAny<int>()))
                .ThrowsAsync(new Exception());
            var controller = GetController(mocks);
            var response = await controller.GetByQuantity(1);
            Assert.Equal((int)HttpStatusCode.InternalServerError, GetStatusCode(response));
        }
    }
}
