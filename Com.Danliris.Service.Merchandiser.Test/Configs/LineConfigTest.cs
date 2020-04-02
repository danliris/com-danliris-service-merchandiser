using Com.Danliris.Service.Merchandiser.Lib.Configs;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Configs
{
   public class LineConfigTest
    {
        [Fact]
        public void Configure_Return_Success()
        {
            //var mockEntityTypeBuilder = new Mock<IEntityTypeBuilder>();
            //var mock = new Mock<EntityTypeBuilder<Line>>();
            //mock.Setup(c=>c.Property)
            //var builder = new EntityTypeBuilder<Line>();
            LineConfig lc = new LineConfig();
            //lc.Configure(mock);

        }
    }
}
