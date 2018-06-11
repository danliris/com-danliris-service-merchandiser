using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using Models = Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services.Efficiency
{
    [Collection("ServiceProviderFixture Collection")]
    public class EfficiencyBasicTest : BasicServiceTest<MerchandiserDbContext, EfficiencyService, Models.Efficiency>
    {
        private static readonly string[] createAttrAssertions = { "InitialRange", "FinalRange", "Value" };
        private static readonly string[] updateAttrAssertions = { "InitialRange", "FinalRange", "Value" };
        private static readonly string[] existAttrCriteria = { };
        public EfficiencyBasicTest(ServiceProviderFixture fixture) : base(fixture, createAttrAssertions, updateAttrAssertions, existAttrCriteria)
        {

        }
        public override void EmptyCreateModel(Models.Efficiency model)
        {
            model.Name = string.Empty;
            model.Code = string.Empty;
            model.Value = 0;
            model.InitialRange = 0;
            model.FinalRange = 0;
        }

        public override void EmptyUpdateModel(Models.Efficiency model)
        {
            model.Name = string.Empty;
            model.Code = string.Empty;
            model.Value = 0;
            model.InitialRange = 0;
            model.FinalRange = 0;
        }

        public override Models.Efficiency GenerateTestModel()
        {
            string guid = Guid.NewGuid().ToString();
            return new Models.Efficiency()
            {
                //Code = guid,
                Name = "test",
                Value = 2,
                InitialRange = 1,
                FinalRange = 2,
            };
        }
    }
}
