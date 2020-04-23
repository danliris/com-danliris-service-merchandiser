using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Test.DataUtilities
{
  public  class LineDataUtil
    {

        private readonly LineService Service;

        public LineDataUtil(LineService service)
        {
            Service = service;
        }

        public Line GetLineModel()
        {
            Line TestData = new Line()
            {
                Name = "name",
               
            };

            return TestData;
        }


        public LineViewModel GetLineViewModel()
        {
            return new LineViewModel()
            {
                Name = "name",
               
            };
        }
    }
}

