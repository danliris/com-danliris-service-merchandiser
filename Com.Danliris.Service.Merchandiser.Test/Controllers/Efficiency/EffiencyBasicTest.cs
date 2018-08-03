using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.DataUtils.EfficiencyDataUtil;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Controllers.Efficiency
{
    [Collection("TestServerFixture Collection")]
    public class EffiencyBasicTest : BasicControllerTest<MerchandiserDbContext, EfficiencyService, Lib.Models.Efficiency, EfficiencyViewModel, EfficiencyDataUtil>
    {
        private static string URI = "v1/efficiencies";
        private static List<string> CreateValidationAttributes = new List<string> {"InitialRange","FinalRange","Value"};
        private static List<string> UpdateValidationAttributes = new List<string> {"InitialRange","FinalRange","Value"};

        public EffiencyBasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
        {
        }
    }
}
