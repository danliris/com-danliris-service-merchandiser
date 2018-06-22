using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.Lib;
using Microsoft.AspNetCore.Authorization;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.PdfTemplates;
using System.IO;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.BasicControllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/ro-garments")]
    [Authorize]
    public class RO_GarmentsController : BasicController<MerchandiserDbContext, RO_GarmentService, RO_GarmentViewModel, RO_Garment>
    {
        private static readonly string ApiVersion = "1.0";
        public RO_GarmentsController(RO_GarmentService service) : base(service, ApiVersion)
        {
        }

        [HttpGet("pdf/{id}")]
        public IActionResult GetPDF([FromRoute]int Id)
        {
            try
            {
                var model = Service.ReadModelById(Id).Result;
                var viewModel = Service.MapToViewModel(model);

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
    }
}