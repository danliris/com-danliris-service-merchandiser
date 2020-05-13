using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Models
{
  public  class RateTest
    {


        [Fact]
        public void Should_Success_Instantiate_Rate()
        {
            string Code = "Code test";
            string Name = "Name test";
            double Value = 1.0;
            Rate ac = new Rate()
            {
                Code = Code,
                Name = Name,
                Value = Value,
            };

            Assert.Equal(Code, ac.Code);
            Assert.Equal(Name, ac.Name);
            Assert.Equal(Value, ac.Value);

        }


       
    }
}
