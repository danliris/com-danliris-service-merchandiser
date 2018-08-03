using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.DataUtils.RateDataUtil;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Controllers.Rate
{
    [Collection("TestServerFixture Collection")]
    public class RateBasicTest : BasicControllerTest<MerchandiserDbContext, RateService, Lib.Models.Rate, RateViewModel, RateDataUtil>
    {

        private static string URI = "v1/rates";
        private static List<string> CreateValidationAttributes = new List<string> { "Name" };
        private static List<string> UpdateValidationAttributes = new List<string> { "Name"};

        public RateBasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
        {
        }
    }
}
