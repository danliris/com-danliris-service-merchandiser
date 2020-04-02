using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
    public class PropertyCopierTest
    {
        [Fact]
        public void Copy_Return_Success()
        {
            PropertyCopier<Line, LineViewModel>.Copy(new Line(), new LineViewModel());
           
        }
    }
}
