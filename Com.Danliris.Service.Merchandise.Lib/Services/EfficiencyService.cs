using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System.Linq.Dynamic.Core;
using Com.Moonlay.NetCore.Lib;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Moonlay.Models;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class EfficiencyService : BasicService<MerchandiserDbContext, Efficiency>, IMap<Efficiency, EfficiencyViewModel>, IEfficiencies
    {
        protected IIdentityService IdentityService;
        public EfficiencyService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public override Tuple<List<Efficiency>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int Size = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<Efficiency> Query = this.DbContext.Efficiencies;

            List<string> SearchAttributes = new List<string>()
                {
                    "InitialRange", "FinalRange", "Value"
                };
            Query = ConfigureSearch(Query, SearchAttributes, Keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code", "InitialRange", "FinalRange", "Value"
                };
            Query = Query
                .Select(b => new Efficiency
                {
                    Id = b.Id,
                    Code = b.Code,
                    InitialRange = b.InitialRange,
                    FinalRange = b.FinalRange,
                    Value = b.Value
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);
            
            Pageable<Efficiency> pageable = new Pageable<Efficiency>(Query, Page - 1, Size);
            List<Efficiency> Data = pageable.Data.ToList<Efficiency>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }

        public async Task<Efficiency> ReadModelByQuantity(int Quantity)
        {
            Efficiency result = await this.DbSet
                .FirstOrDefaultAsync(eff => Quantity > 0 && eff.InitialRange <= Quantity && eff.FinalRange >= Quantity && eff.IsDeleted == false);
            if (result == null)
            {
                return new Efficiency()
                {
                    Id = 0,
                    Value = 0
                };
            }
            return result;
        }

        public override void OnCreating(Efficiency model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));
            model.Name = model.InitialRange + " S/D " + model.FinalRange;

            base.OnCreating(model);
        }

        public override void OnUpdating(int id, Efficiency model)
        {
            model.Name = model.InitialRange + " S/D " + model.FinalRange;

            base.OnUpdating(id, model);
        }

        public EfficiencyViewModel MapToViewModel(Efficiency model)
        {
            EfficiencyViewModel viewModel = new EfficiencyViewModel();
            PropertyCopier<Efficiency, EfficiencyViewModel>.Copy(model, viewModel);
            viewModel.InitialRange = model.InitialRange;
            viewModel.FinalRange = model.FinalRange;
            viewModel.Value = model.Value * 100;
            return viewModel;
        }

        public Efficiency MapToModel(EfficiencyViewModel viewModel)
        {
            Efficiency model = new Efficiency();
            PropertyCopier<EfficiencyViewModel, Efficiency>.Copy(viewModel, model);
            model.InitialRange = (int)viewModel.InitialRange;
            model.FinalRange = (int)viewModel.FinalRange;
            model.Value = (double)viewModel.Value / 100;
            return model;
        }

        public ReadResponse<Efficiency> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            var dataModel = ReadModel(page, size, order, select, keyword, filter);


            return new ReadResponse<Efficiency>(dataModel.Item1, dataModel.Item2, dataModel.Item3, dataModel.Item4);
        }

        public Task<Efficiency> ReadByIdAsync(int id)
        {
            return  this.DbSet
                .Where(eff => eff.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Efficiency model)
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


        public override Task<Efficiency> ReadModelById(int id)
        {
            return this.DbSet.Where(eff => eff.Id.Equals(id) && eff.IsDeleted.Equals(false))
               .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
           
            var model = await this.ReadModelById(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(int id, Efficiency model)
        {
          

            EntityExtension.FlagForUpdate(model, IdentityService.Username, UserAgent);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }
    }
}
