using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using AutoMapper;
using System;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/rates")]
    [Authorize]
    public class RatesController : BasicController<Rate, RateViewModel, IRates>
    {
        private readonly static string apiVersion = "1.0";
        private readonly IIdentityService Service;
        public RatesController(IIdentityService identityService, IValidateService validateService, IRates facade,  IServiceProvider serviceProvider) : base(identityService, validateService, facade, apiVersion)
        {
            Service = identityService;
        }
    }
}