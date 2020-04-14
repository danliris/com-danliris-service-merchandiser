using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using AutoMapper;
using System;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/article-colors")]
    [Authorize]
    public class ArticleColorController : BasicController<ArticleColor, ArticleColorViewModel, IArticleColor>
    {
        private readonly static string apiVersion = "1.0";
        private readonly IIdentityService Service;
        public ArticleColorController(IIdentityService identityService, IValidateService validateService, IArticleColor facade, IServiceProvider serviceProvider) : base(identityService, validateService, facade, apiVersion)
        {
            Service = identityService;
        }
    }
}