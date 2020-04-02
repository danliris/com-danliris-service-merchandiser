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
   public class RO_Garment_SizeBreakdown_DetailServiceTest
    {
        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_RO_Garment_SizeBreakdown_DetailService()
        {
            RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider().Object);

        }

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            RO_Garment_SizeBreakdown_Detail model = new RO_Garment_SizeBreakdown_Detail();
            RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider().Object);
            var result = RO_Garment_Size_Detail_ServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            RO_Garment_SizeBreakdown_DetailViewModel viewmodel = new RO_Garment_SizeBreakdown_DetailViewModel();
            RO_Garment_SizeBreakdown_DetailService RO_Garment_Size_Detail_ServiceObj = new RO_Garment_SizeBreakdown_DetailService(GetServiceProvider().Object);
            var result = RO_Garment_Size_Detail_ServiceObj.MapToModel(viewmodel);
            Assert.NotNull(result);
        }

    }
}
