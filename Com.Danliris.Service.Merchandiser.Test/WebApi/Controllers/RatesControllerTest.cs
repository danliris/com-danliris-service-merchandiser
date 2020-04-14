using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.WebApi.Utils;
using Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.WebApi.Controllers
{
    public class RatesControllerTest : BasicControllerTest<RatesController, Rate, RateViewModel, IRates>
    {
        [Fact]
        public void Validate_Default()
        {
            RateViewModel defaultViewModel = new RateViewModel();

            var defaultValidationResult = defaultViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_Filled()
        {
            var mock = GetMocks();

            mock.Facade.Setup(s => s.ReadModel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<List<string>>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new Tuple<List<Rate>, int, Dictionary<string, string>, List<string>>(new List<Rate>(), 1, new Dictionary<string, string>(), new List<string>()));

            mock.ServiceProvider.Setup(s => s.GetService(typeof(IRates)))
                .Returns(mock.Facade.Object);

            RateViewModel filledViewModel = new RateViewModel
            {
                Name = "Name",
                //Unit = new UnitViewModel { Id = 1 },
                Value = 0
            };

            ValidationContext validationContext = new ValidationContext(filledViewModel, mock.ServiceProvider.Object, null);

            var filledValidationResult = filledViewModel.Validate(validationContext);
            Assert.True(filledValidationResult.Count() > 0);
        }

    }
}
