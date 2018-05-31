using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using Models = Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services.Rate
{
    [Collection("ServiceProviderFixture Collection")]
    public class RateBasicTest : BasicServiceTest<MerchandiserDbContext, RateService, Models.Rate>
    {
        private static readonly string[] createAttrAssertions = { "Name" };
        private static readonly string[] updateAttrAssertions = { "Name" };
        private static readonly string[] existAttrCriteria = { };
        public RateBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(Models.Rate model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.Value = 0;

        }

        public override void EmptyUpdateModel(Models.Rate model)
        {
            model.Code = string.Empty;
            model.Name = string.Empty;
            model.Value = 0;
        }

        public override Models.Rate GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();
            return new Models.Rate()
            {
                Code = guid,
                Name = string.Format("Test {0}", guid),
                Value = 1,
            };
        }
    }
}
