using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
   public class ArticleColorViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_ArticleColorViewModel()
        {
            string Name = "name test";
            string Description = "Description test";
            ArticleColorViewModel avm = new ArticleColorViewModel()
            {
                Name = Name,
                Description = Description
            };

            Assert.Equal(Name, avm.Name);
            Assert.Equal(Description, avm.Description);
            var defaultValidationResult = avm.Validate(null);
            Assert.False(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            ArticleColorViewModel avm = new ArticleColorViewModel();
            var defaultValidationResult = avm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
