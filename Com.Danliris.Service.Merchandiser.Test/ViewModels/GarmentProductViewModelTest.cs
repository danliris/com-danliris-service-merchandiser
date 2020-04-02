using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
  public  class GarmentProductViewModelTest
    {
        [Fact]
        public void Validate_deafult()
        {
            GarmentProductViewModel defaultViewModel = new GarmentProductViewModel()
            {
                code = "code test",
                composition = "composition test",
                construction = "construction test",
                yarn = "yarn test",
                width = "width test"
            };

            Assert.Equal("code test", defaultViewModel.code);
            Assert.Equal("composition test", defaultViewModel.composition);
            Assert.Equal("construction test", defaultViewModel.construction);
            Assert.Equal("yarn test", defaultViewModel.yarn);
            Assert.Equal("width test", defaultViewModel.width);
            Assert.Throws<NotImplementedException>(() => defaultViewModel.Validate(null));
        }

        [Fact]
        public void Validate_Return_Exception()
        {
            GarmentProductViewModel defaultViewModel = new GarmentProductViewModel();
            Assert.Throws<NotImplementedException>(() => defaultViewModel.Validate(null));
        }

    }
}
