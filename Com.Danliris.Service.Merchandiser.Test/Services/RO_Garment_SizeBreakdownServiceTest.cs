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
  public  class RO_Garment_SizeBreakdownServiceTest
    {

        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            //serviceProvider
            //    .Setup(x => x.GetService(typeof(RO_Garment_SizeBreakdown_DetailService)))
            //    .Returns(new RO_Garment_SizeBreakdown_DetailService() { });

            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_RO_Garment_SizeBreakdownService()
        {
            RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider().Object);

        }


        //[Fact]
        //public void MapToViewModel_Return_Success()
        //{
        //    RO_Garment_SizeBreakdown model = new RO_Garment_SizeBreakdown()
        //    {
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>() { new RO_Garment_SizeBreakdown_Detail() { RO_Garment_SizeBreakdownId = 1 } }
        //    };
        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider().Object);
        //    var result = RO_Garment_SizeBreakdownServiceObj.MapToViewModel(model);
        //    Assert.NotNull(result);
        //}


        //[Fact]
        //public void MapToModel_Return_Success()
        //{
        //    RO_Garment_SizeBreakdownViewModel viewmodel = new RO_Garment_SizeBreakdownViewModel()
        //    {
        //        Color = new ArticleColorViewModel() {Id=1,Name="nama"},
        //        RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_DetailViewModel>() { new RO_Garment_SizeBreakdown_DetailViewModel() { } }
        //    };
        //    RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownServiceObj = new RO_Garment_SizeBreakdownService(GetServiceProvider().Object) {

        //    };


        //    var result = RO_Garment_SizeBreakdownServiceObj.MapToModel(viewmodel);
        //    Assert.NotNull(result);
        //}

    }
}
