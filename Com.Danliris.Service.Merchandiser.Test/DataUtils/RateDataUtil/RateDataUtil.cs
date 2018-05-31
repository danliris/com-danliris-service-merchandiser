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

namespace Com.Danliris.Service.Merchandiser.Test.DataUtils.RateDataUtil
{
    public class RateDataUtil : BasicDataUtil<MerchandiserDbContext, RateService, Rate>, IEmptyData<RateViewModel>
    {
        public RateDataUtil(MerchandiserDbContext dbContext, RateService service) : base(dbContext, service)
        {

        }
        public RateViewModel GetEmptyData()
        {
            RateViewModel Data = new RateViewModel();
            Data.Name = string.Empty;
            Data.Value = 0;
            return Data;
        }

        public override Rate GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            Rate TestData = new Rate
            {
                Name = string.Format("Test {0}", guid),
                Value = 1,
            };

            return TestData;
        }

        public override async Task<Rate> GetTestDataAsync()
        {
            Rate Data = GetNewData();
            await this.Service.CreateModel(Data);
            return Data;
        }
    }
}
