using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
 public   class StoreViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_StoreViewModel()
        {
            string code = "code test";
            string name = "name test";
            string description = "description test";
            var svm = new StoreViewModel();
            svm.code = code;
            svm.name = name;
            svm.description = description;

            Assert.Equal(code, svm.code);
            Assert.Equal(name, svm.name);
            Assert.Equal(description, svm.description);
        }
    }
}
