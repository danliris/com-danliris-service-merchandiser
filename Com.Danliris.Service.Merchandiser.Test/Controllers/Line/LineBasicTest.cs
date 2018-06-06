using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.DataUtils.LineDataUtil;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Controllers.Line
{
    [Collection("TestServerFixture Collection")]
    public class LineBasicTest : BasicControllerTest<MerchandiserDbContext, LineService, Lib.Models.Line, LineViewModel, LineDataUtil>
    {

        private static string URI = "v1/Lines";
        private static List<string> CreateValidationAttributes = new List<string> { "Name", "Code" };
        private static List<string> UpdateValidationAttributes = new List<string> { "Name", "Code" };

        public LineBasicTest(TestServerFixture fixture) : base(fixture, URI, CreateValidationAttributes, UpdateValidationAttributes)
        {
        }
    }
}
