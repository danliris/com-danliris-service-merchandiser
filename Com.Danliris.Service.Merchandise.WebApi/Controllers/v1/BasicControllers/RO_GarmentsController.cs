using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.Lib;
using Microsoft.AspNetCore.Authorization;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.PdfTemplates;
using System.IO;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using AutoMapper;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.BasicControllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/ro-garments")]
    [Authorize]
    public class RO_GarmentsController : BasicController<RO_Garment, RO_GarmentViewModel, IROGarment>
    {
        private readonly static string apiVersion = "1.0";
        private readonly IIdentityService Service;
        public RO_GarmentsController(IIdentityService identityService, IValidateService validateService, IROGarment facade, IMapper mapper, IServiceProvider serviceProvider) : base(identityService, validateService, facade, mapper, apiVersion)
        {
            Service = identityService;
        }

        [HttpGet("pdf/{id}")]
        public async Task<IActionResult> GetPDFAsync([FromRoute]int Id)
        {
            try
            {
                RO_Garment model = await Facade.ReadByIdAsync(Id);
                RO_GarmentViewModel viewModel = Mapper.Map<RO_GarmentViewModel>(model);

                int timeoffsset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);
                ROGarmentPdfTemplate PdfTemplate = new ROGarmentPdfTemplate();
                MemoryStream stream = PdfTemplate.GeneratePdfTemplate(viewModel, timeoffsset);

                return new FileStreamResult(stream, "application/pdf")
                {
                    FileDownloadName = "RO Penjualan Umum " + viewModel.CostCalculationGarment.RO_Number + ".pdf"
                };
            }
            catch (System.Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpPost("post")]
        public async Task<IActionResult> PostRO([FromBody]List<long> listId)
        {
            try
            {
                ValidateUser();

                int result = await Facade.PostRO(listId);
                if (result < 1)
                {
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, "No changes applied.")
                        .Fail();
                    return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
                }
                return NoContent();
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpPut("unpost/{id}")]
        public async Task<IActionResult> UnpostRO(long id)
        {
            try
            {
                ValidateUser();

                await Facade.UnpostRO(id);
                return NoContent();
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }
    }
}