using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
    public class BuyerViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_ArticleColorViewModel()
        {
            string code = "code test";
            string name = "name test";
            string email = "danrilist@moonlay.com";
            string address1 = "address1 test";
            string address2 = "address1 test";
            BuyerViewModel bvm = new BuyerViewModel()
            {
                code = code,
                name = name,
                email = email,
                address1 = address1,
                address2 =address2
            };

            Assert.Equal(code, bvm.code);
            Assert.Equal(name, bvm.name);
            Assert.Equal(email, bvm.email);
            Assert.Equal(address1, bvm.address1);
            Assert.Equal(address2, bvm.address2);
        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            BuyerViewModel bvm = new BuyerViewModel();
            var defaultValidationResult = bvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_withFilledWrongEmail_Return_Success()
        {
            BuyerViewModel bvm = new BuyerViewModel()
            {
                code = "code test",
                name = "name test",
                email = "any wrong email",
                address1 = "address1 test",
                address2 = "address2 test"
            };
            var defaultValidationResult = bvm.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

        [Fact]
        public void Validate_withFilledValidEmail_Return_Fail()
        {
            BuyerViewModel bvm = new BuyerViewModel()
            {
                code = "code test",
                name = "name test",
                email = "danrilist@moonlay.com",
                address1 = "address1 test",
                address2 = "address2 test"
            };
            var defaultValidationResult = bvm.Validate(null);
            Assert.False(defaultValidationResult.Count() > 0);
        }

    }
}
