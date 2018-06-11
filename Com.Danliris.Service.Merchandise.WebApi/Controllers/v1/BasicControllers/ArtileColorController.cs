using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/article-colors")]
    [Authorize]
    public class ArticleColorController : BasicController<MerchandiserDbContext, ArticleColorService, ArticleColorViewModel, ArticleColor>
    {
        private static readonly string ApiVersion = "1.0";
        public ArticleColorController(ArticleColorService service) : base(service, ApiVersion)
        {
        }
    }
}