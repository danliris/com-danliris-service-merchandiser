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

namespace Com.Danliris.Service.Merchandiser.Test.DataUtils.EfficiencyDataUtil
{
    public class EfficiencyDataUtil : BasicDataUtil<MerchandiserDbContext, EfficiencyService, Efficiency>, IEmptyData<EfficiencyViewModel>
    {

        public EfficiencyDataUtil(MerchandiserDbContext dbContext, EfficiencyService service) : base(dbContext, service)
        {

        }

        public EfficiencyViewModel GetEmptyData()
        {
            EfficiencyViewModel Data = new EfficiencyViewModel();

            Data.Name = "";
            Data.Code = "";
            Data.FinalRange = 0;
            Data.InitialRange = 0;
            Data.Value = 0;
            return Data;
        }

        public override Efficiency GetNewData()
        {
            string guid = Guid.NewGuid().ToString();
            Efficiency TestData = new Efficiency
            {
                Name="TEST",
                FinalRange = 2,
                InitialRange = 1,
                Value = 2,
            };

            return TestData;
        }

        public override async Task<Efficiency> GetTestDataAsync()
        {
            Efficiency Data = GetNewData();
            await this.Service.CreateModel(Data);
            return Data;
        }
    }
}
