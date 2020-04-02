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
    public class EfficiencyServiceTest
    {
        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_EfficiencyService()
        {
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider().Object);

        }

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            Efficiency model = new Efficiency();
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider().Object);
            var result = EfficiencyServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            EfficiencyViewModel viewModel = new EfficiencyViewModel()
            {
                InitialRange = 1,
                FinalRange =1,
                Value=1
            };
            EfficiencyService EfficiencyServiceObj = new EfficiencyService(GetServiceProvider().Object);
            var result = EfficiencyServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }


    }
}
