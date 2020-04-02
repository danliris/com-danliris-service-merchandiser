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
   public class RateServiceTest
    {

        public Mock<IServiceProvider> GetServiceProvider()
        {
            var serviceProvider = new Mock<IServiceProvider>();


            return serviceProvider;
        }

        [Fact]
        public void Should_Success_Instantiate_RateService()
        {
            RateService RateServiceObj = new RateService(GetServiceProvider().Object);

        }

        //[Fact]
        //public void OnCreating_Return_Success()
        //{
        //    Rate model = new Rate()
        //    {
        //        Code = "Q1XT4ZG7"
        //    };
        //    RateService RateServiceObj = new RateService(GetServiceProvider().Object);
        //    RateServiceObj.OnCreating(model);
        //}

        [Fact]
        public void MapToViewModel_Return_Success()
        {
            Rate model = new Rate();
            RateService RateServiceObj = new RateService(GetServiceProvider().Object);
            var result = RateServiceObj.MapToViewModel(model);
            Assert.NotNull(result);
        }

        [Fact]
        public void MapToModel_Return_Success()
        {
            RateViewModel viewModel = new RateViewModel()
            {
                Value = 1.0,
            };
            RateService RateServiceObj = new RateService(GetServiceProvider().Object);
            var result = RateServiceObj.MapToModel(viewModel);
            Assert.NotNull(result);
        }
    }
}
