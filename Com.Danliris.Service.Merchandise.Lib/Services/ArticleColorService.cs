using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Com.Moonlay.NetCore.Lib;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Moonlay.Models;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class ArticleColorService : BasicService<MerchandiserDbContext, ArticleColor>, IMap<ArticleColor, ArticleColorViewModel>, IArticleColor
   
    {
        protected IIdentityService IdentityService;
        public ArticleColorService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public override Tuple<List<ArticleColor>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int Size = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<ArticleColor> Query = this.DbContext.ArticleColors;

            List<string> SearchAttributes = new List<string>()
                {
                    "Name"
                };
            Query = ConfigureSearch(Query, SearchAttributes, Keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Name"
                };
            Query = Query
                .Select(b => new ArticleColor
                {
                    Id = b.Id,
                    Name = b.Name,
                    LastModifiedUtc = b.LastModifiedUtc
                });

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);

            Pageable<ArticleColor> pageable = new Pageable<ArticleColor>(Query, Page - 1, Size);
            List<ArticleColor> Data = pageable.Data.ToList<ArticleColor>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }

        public ArticleColorViewModel MapToViewModel(ArticleColor model)
        {
            ArticleColorViewModel viewModel = new ArticleColorViewModel();
            PropertyCopier<ArticleColor, ArticleColorViewModel>.Copy(model, viewModel);
            return viewModel;
        }

        public ArticleColor MapToModel(ArticleColorViewModel viewModel)
        {
            ArticleColor model = new ArticleColor();
            PropertyCopier<ArticleColorViewModel, ArticleColor>.Copy(viewModel, model);
            return model;
        }

        public ReadResponse<ArticleColor> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {

            var dataModel = ReadModel(page, size, order, select, keyword, filter);
            

            return new ReadResponse<ArticleColor>(dataModel.Item1, dataModel.Item2, dataModel.Item3, dataModel.Item4);
        }

        public override Task<ArticleColor> ReadModelById(int id)
        {
            return this.DbSet.Where(eff => eff.Id.Equals(id) && eff.IsDeleted.Equals(false))
               .FirstOrDefaultAsync();
        }

        public Task<ArticleColor> ReadByIdAsync(int id)
        {
            return this.DbSet
                .Where(eff => eff.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var model = await this.ReadModelById(id);
            EntityExtension.FlagForDelete(model, IdentityService.Username, UserAgent, true);
            DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }

        public new async Task<int> CreateAsync(ArticleColor model)
        {
            //do
            //{
            //    model.Id = Code.Generate();
            //}
            // while (this.DbSet.Any(d => d.Code.Equals(model.Code)));
           

            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
            this.DbSet.Add(model);
            return await this.DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(int id, ArticleColor model)
        {
            EntityExtension.FlagForUpdate(model, IdentityService.Username, UserAgent);
            this.DbSet.Update(model);
            return await DbContext.SaveChangesAsync();
        }
    }
}
