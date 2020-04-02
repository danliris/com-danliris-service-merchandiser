using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
   public class LineTest
    {
        [Fact]
        public void Should_Success_Instantiate_Line()
        {
            string Code = "Code test";
            string Name = "Name test";
           
            Line ac = new Line()
            {
                Code = Code,
                Name = Name,
            };

            Assert.Equal(Code, ac.Code);
            Assert.Equal(Name, ac.Name);
            
        }


        [Fact]
        public void Validate_withDefault_Return_Success()
        {
            Line ac = new Line();
            var defaultValidationResult = ac.Validate(null);
            Assert.True(defaultValidationResult.Count() == 0);
        }
    }
}
