using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.BusinessLogic
{
    public class ArticleColorFacade : IArticleColor
    {
        private const string UserAgent = "merchandiser-service";
        protected DbSet<ArticleColor> DbSet;
        protected IIdentityService IdentityService;
        public MerchandiserDbContext DbContext;
        public ArticleColorFacade(IServiceProvider serviceProvider, MerchandiserDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<ArticleColor>();
            IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        public override void OnCreating(TModel model)
        {
            base.OnCreating(model);
            model._CreatedAgent = "merchandiser-service";
            model._CreatedBy = this.Username;
            model._LastModifiedAgent = "merchandiser-service";
            model._LastModifiedBy = this.Username;
        }

        public Task<int> CreateAsync(ArticleColor model)
        {
            EntityExtension
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ReadResponse<ArticleColor> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleColor> ReadByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, ArticleColor model)
        {
            throw new NotImplementedException();
        }
    }
}
