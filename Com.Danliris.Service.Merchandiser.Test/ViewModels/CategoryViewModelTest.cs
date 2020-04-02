using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
   public class CategoryViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_CategoryViewModel()
        {
            string code = "code test";
            string name = "name test";
            string SubCategory = "SubCategory test";
            CategoryViewModel cvm = new CategoryViewModel()
            {
                code= code,
                name = name,
                SubCategory = SubCategory,
            };

            Assert.Equal(code, cvm.code);
            Assert.Equal(name, cvm.name);
            Assert.Equal(SubCategory, cvm.SubCategory);
        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            var defaultValidationResult = cvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
