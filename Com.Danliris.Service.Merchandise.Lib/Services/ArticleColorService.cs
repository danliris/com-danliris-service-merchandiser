using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Moonlay.NetCore.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class ArticleColorService : BasicService<MerchandiserDbContext, ArticleColor>, IMap<ArticleColor, ArticleColorViewModel>, IArticleColor
    {
        public ArticleColorService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
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
                    _LastModifiedUtc = b._LastModifiedUtc
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

    }
}
