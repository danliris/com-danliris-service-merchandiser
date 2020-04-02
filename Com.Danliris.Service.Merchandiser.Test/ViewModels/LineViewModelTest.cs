using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
 public   class LineViewModelTest
    {
        [Fact]
        public void Validate_Default()
        {
            LineViewModel defaultViewModel = new LineViewModel();

            var defaultValidationResult = defaultViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
