using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/rates")]
    [Authorize]
    public class RatesController : BasicController<MerchandiserDbContext, RateService, RateViewModel, Rate>
    {
        private static readonly string ApiVersion = "1.0";
        public RatesController(RateService service) : base(service, ApiVersion)
        {
        }
    }
}