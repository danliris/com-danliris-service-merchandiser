using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System.Linq.Dynamic.Core;
using Com.Moonlay.NetCore.Lib;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class CostCalculationGarment_MaterialService : BasicService<MerchandiserDbContext, CostCalculationGarment_Material>
    {
        public CostCalculationGarment_MaterialService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Tuple<List<CostCalculationGarment_Material>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int CostCalculationGarment_Material = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<CostCalculationGarment_Material> Query = this.DbContext.CostCalculationGarment_Materials;

            List<string> SearchAttributes = new List<string>()
                {
                    "Code"
                };
            Query = ConfigureSearch(Query, SearchAttributes, Keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code"
                };
            Query = Query
                .Select(b => new CostCalculationGarment_Material
                {
                    Id = b.Id,
                    Code = b.Code
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);

            Pageable<CostCalculationGarment_Material> pageable = new Pageable<CostCalculationGarment_Material>(Query, Page - 1, CostCalculationGarment_Material);
            List<CostCalculationGarment_Material> Data = pageable.Data.ToList<CostCalculationGarment_Material>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }

        //public async Task GeneratePO(CostCalculationGarment_Material model)
        //{
        //    string category = model.CategoryName.Substring(0, 3).ToUpper();
        //    int latestSN_Garment = this.DbSet
        //        .Where(d => d.CategoryName.Substring(0, 3).ToUpper() == category && d._CreatedUtc.Year == model._CreatedUtc.Year)
        //        .DefaultIfEmpty()
        //        .Max(d => d.PO_SerialNumber)
        //        .GetValueOrDefault();
        //    //int latestSN_Retail = this.DbContext.CostCalculationRetail_Materials
        //    //    .Where(d => d.CategoryName.Substring(0, 3).ToUpper() == category && d._CreatedUtc.Year == model._CreatedUtc.Year)
        //    //    .DefaultIfEmpty()
        //    //    .Max(d => d.PO_SerialNumber)
        //    //    .GetValueOrDefault();
        //    //int latestSN = Math.Max(latestSN_Garment, latestSN_Retail);
        //    //int latestSN = Math.Max(latestSN_Garment, latestSN_Retail);
        //    //model.PO_SerialNumber = latestSN != 0 ? latestSN + 1 : 1;
        //    if (category == "FABRIC")
        //        model.PO = String.Format("{0}{1}{2:D5}", "PM", model._CreatedUtc.ToString("yy"), model.PO_SerialNumber);
        //    else
        //        model.PO = String.Format("{0}{1}{2:D5}", "PA", model._CreatedUtc.ToString("yy"), model.PO_SerialNumber);
        //    await this.UpdateModel(model.Id, model);
        //}

        public async Task<CostCalculationGarment_Material> GeneratePO(CostCalculationGarment_Material Model)
        {
            string codePO = Model.CategoryName == "FABRIC" ? "PM":  "PA";
            string convection = Model.Convection; 

            var lastData = await this.DbSet.Where(w => w._IsDeleted == false && w.CategoryName == Model.CategoryName && w.Convection == convection).OrderByDescending(o => o._CreatedUtc).FirstOrDefaultAsync();

            DateTime Now = DateTime.Now;
            string Year = Now.ToString("yy");

            if (lastData == null)
            {
                Model.AutoIncrementNumber = 1;
                string Number = Model.AutoIncrementNumber.ToString().PadLeft(4, '0');
                Model.PO_SerialNumber = $"{codePO}{Year}{convection}{Number}";
            }
            else
            {
                if (lastData._CreatedUtc.Year < Now.Year)
                {
                    Model.AutoIncrementNumber = 1;
                    string Number = Model.AutoIncrementNumber.ToString().PadLeft(4, '0');
                    Model.PO_SerialNumber = $"{codePO}{Year}{convection}{Number}";
                }
                else
                {
                    Model.AutoIncrementNumber = lastData.AutoIncrementNumber + 1;
                    string Number = Model.AutoIncrementNumber.ToString().PadLeft(4, '0');
                    Model.PO_SerialNumber = $"{codePO}{Year}{convection}{Number}";
                }
            }

            return Model;
        }

        public override async Task<int> CreateModel(CostCalculationGarment_Material Model)
        {
            int Created = 0;

            Created = await this.CreateAsync(Model);

            await this.UpdateAsync(Model.Id, Model);

            return Created;
        }

        public override void OnCreating(CostCalculationGarment_Material model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));

            base.OnCreating(model);
        }
    }
}
