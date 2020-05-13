using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Moonlay.Models;
using Com.Moonlay.NetCore.Lib;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class RateService : BasicService<MerchandiserDbContext, Rate>, IMap<Rate, RateViewModel>,IRates
    {
        protected IIdentityService IdentityService;
        public RateService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            IdentityService = serviceProvider.GetService<IIdentityService>();
        }
        
        public override Tuple<List<Rate>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int Size = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<Rate> Query = this.DbContext.Rates;

            List<string> SearchAttributes = new List<string>()
                {
                    "Name"
                };
            Query = ConfigureSearch(Query, SearchAttributes, Keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code", "Name", "Value"
                };
            Query = Query
                .Select(b => new Rate
                {
                    Id = b.Id,
                    Code = b.Code,
                    Name = b.Name,
                    Value = b.Value
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);

            Pageable<Rate> pageable = new Pageable<Rate>(Query, Page - 1, Size);
            List<Rate> Data = pageable.Data.ToList<Rate>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }

        public override void OnCreating(Rate model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));

            base.OnCreating(model);
        }

       

        public RateViewModel MapToViewModel(Rate model)
        {
            RateViewModel viewModel = new RateViewModel();
            PropertyCopier<Rate, RateViewModel>.Copy(model, viewModel);
            viewModel.Value = model.Value;
            return viewModel;
        }

        public Rate MapToModel(RateViewModel viewModel)
        {
            Rate model = new Rate();
            PropertyCopier<RateViewModel, Rate>.Copy(viewModel, model);
            model.Value = (double)viewModel.Value;
            return model;
        }

        public ReadResponse<Rate> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            var dataModel = ReadModel(page, size, order, select, keyword, filter);


            return new ReadResponse<Rate>(dataModel.Item1, dataModel.Item2, dataModel.Item3, dataModel.Item4);
        }

        public override Task<Rate> ReadModelById(int id)
        {
            return this.DbSet.Where(eff => eff.Id.Equals(id) && eff.IsDeleted.Equals(false))
               .FirstOrDefaultAsync();
        }

        public async Task<Rate> ReadByIdAsync(int id)
        {
            Rate result = await this.DbSet
                .Where(eff => eff.Id.Equals(id))
                .FirstOrDefaultAsync();

            return result;
        }


        public async Task<int> DeleteAsync(int id)
        {
            var model = await this.ReadModelById(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            DbSet.Update(model);

            return await DbContext.SaveChangesAsync();
        }

        public  async Task<int> CreateAsync(Rate model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));
            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            this.DbSet.Add(model);
            
            return await this.DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(int id, Rate model)
        {
            EntityExtension.FlagForUpdate(model, IdentityService.Username, UserAgent);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }
    }
}
