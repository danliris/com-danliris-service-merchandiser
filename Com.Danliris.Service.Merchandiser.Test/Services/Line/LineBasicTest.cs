using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using Models = Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services.Line
{
    [Collection("ServiceProviderFixture Collection")]
    public class LineBasicTest : BasicServiceTest<MerchandiserDbContext, LineService, Models.Line>
    {
        private static readonly string[] createAttrAssertions = { "Name", "Code" };
        private static readonly string[] updateAttrAssertions = { "Name", "Code" };
        private static readonly string[] existAttrCriteria = { };
        public LineBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {
        }

        public override void EmptyCreateModel(Models.Line model)
        {
            model.Name = string.Empty;
            model.Code = string.Empty;
        }

        public override void EmptyUpdateModel(Models.Line model)
        {
            model.Name = string.Empty;
            model.Code = string.Empty;
        }

        public override Models.Line GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();
            return new Models.Line()
            {
                Code = guid,
                Name = string.Format("Test Buyer {0}", guid),
            };
        }
    }
}
