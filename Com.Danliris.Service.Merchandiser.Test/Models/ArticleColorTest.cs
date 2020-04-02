using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
    public class ArticleColorTest
    {
        [Fact]
        public void Should_Success_Instantiate_ArticleColorTest()
        {
            string Name = "Name test";
            string Description = "Description test";
            ArticleColor ac = new ArticleColor()
            {
                Name=Name,
                Description = Description,
            };

            Assert.Equal(Name, ac.Name);
            Assert.Equal(Description, ac.Description);
        }

        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            ArticleColor ac = new ArticleColor();
            var defaultValidationResult = ac.Validate(null);
            Assert.True(defaultValidationResult.Count() == 0);
        }
    }
}
