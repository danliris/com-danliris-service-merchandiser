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
  public  class ArticleColorServiceTest
    {

        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_ArticleColorService()
        {
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider().Object);

        }

       

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            ArticleColor model = new ArticleColor();
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider().Object);
            var result = ArticleColorServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            ArticleColorViewModel viewModel = new ArticleColorViewModel()
            {
               
            };
            ArticleColorService ArticleColorServiceObj = new ArticleColorService(GetServiceProvider().Object);
            var result = ArticleColorServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
