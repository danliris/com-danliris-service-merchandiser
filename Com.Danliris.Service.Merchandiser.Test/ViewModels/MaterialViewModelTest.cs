using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;
using static Com.Danliris.Service.Merchandiser.Lib.ViewModels.MaterialViewModel;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
   public class MaterialViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_MaterialViewModel()
        {
            string code = "code test";
            string name = "name test";
            string description = "description test";
            string composition = "composition test";
            string construction = "construction test";
            string width = "width test";
            string yarn = "yarn test";
            int categoryId =1;

            int id = 2;
            string codeCvm = "Code cvm";
            string nameCvm = "Name cvm";
            string subCategory = "SubCategory cvm";

            CategoryVM cvm = new CategoryVM();
            cvm.Id = id;
            cvm.Code = codeCvm;
            cvm.Name = nameCvm;
            cvm.SubCategory = subCategory;

            Assert.Equal(id, cvm.Id);
            Assert.Equal(codeCvm, cvm.Code);
            Assert.Equal(nameCvm, cvm.Name);
            Assert.Equal(subCategory, cvm.SubCategory);

            var mvm = new MaterialViewModel();

            mvm.Code = code;
            mvm.Name = name;

            mvm.Description = description;
            mvm.Composition = composition;
            mvm.Construction=construction;
            mvm.Width = width;
            mvm.Yarn = yarn;
            mvm.CategoryId = categoryId;
            mvm.Category = cvm;

            Assert.Equal(code, mvm.Code);
            Assert.Equal(name, mvm.Name);

            Assert.Equal(description, mvm.Description);
            Assert.Equal(composition, mvm.Composition);
            Assert.Equal(construction, mvm.Construction);
            Assert.Equal(width, mvm.Width);
            Assert.Equal(yarn, mvm.Yarn);
            Assert.Equal(categoryId, mvm.CategoryId);
            Assert.Equal(cvm, mvm.Category);

        }

        [Fact]
        public void Validate_Default()
        {
            MaterialViewModel mvm = new MaterialViewModel();

            var defaultValidationResult = mvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

    }
}
