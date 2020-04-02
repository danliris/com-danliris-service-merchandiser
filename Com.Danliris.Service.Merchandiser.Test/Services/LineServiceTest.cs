using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
   public class LineServiceTest
    {

        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            //serviceProvider
            //    .Setup(x => x.GetService(typeof(IHttpClientService)))
            //    .Returns(new HttpClientTestService());

            //serviceProvider
            //    .Setup(x => x.GetService(typeof(IIdentityService)))
            //    .Returns(new IdentityService() { Token = "Token", Username = "Test" });


            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_LineServiceService()
        {
            LineService LineServiceObj = new LineService(GetServiceProvider().Object);
            
        }

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            Line model = new Line();
            LineService LineServiceObj = new LineService(GetServiceProvider().Object);
           var result= LineServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            LineViewModel viewModel = new LineViewModel();
            LineService LineServiceObj = new LineService(GetServiceProvider().Object);
            var result = LineServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
