using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Test.Helpers;
using Com.Danliris.Service.Merchandiser.Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Test.DataUtils.LineDataUtil
{
    public class LineDataUtil : BasicDataUtil<MerchandiserDbContext, LineService, Line>, IEmptyData<LineViewModel>
    {

        public LineDataUtil(MerchandiserDbContext dbContext, LineService service) : base(dbContext, service)
        {

        }

        public LineViewModel GetEmptyData()
        {
            LineViewModel Data = new LineViewModel();

            Data.Name = "";
            Data.Code = "";
            return Data;
        }

        public override Line GetNewData()
        {

            Line TestData = new Line
            {
                Name = "TestName",
                Code = "Test",
            };

            return TestData;
        }

        public override async Task<Line> GetTestDataAsync()
        {
            Line Data = GetNewData();
            await this.Service.CreateModel(Data);
            return Data;
        }
    }
}
