using Microsoft.AspNetCore.Mvc;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Com.Danliris.Service.Merchandiser.Lib.PdfTemplates;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using AutoMapper;

namespace Com.Danliris.Service.Merchandiser.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/cost-calculation-garments")]
    [Authorize]
    public class CostCalculationGarmentsController : BasicController<CostCalculationGarment, CostCalculationGarmentViewModel, ICostCalculationGarments>
    {
        private readonly static string apiVersion = "1.0";
        private readonly IIdentityService Service;
        public CostCalculationGarmentsController(IIdentityService identityService, IValidateService validateService, ICostCalculationGarments facade, IMapper mapper, IServiceProvider serviceProvider) : base(identityService, validateService, facade, mapper, apiVersion)
        {
            Service = identityService;
        }

        [HttpGet("pdf/{Id}")]
        public async Task<IActionResult> GetPDF([FromRoute]int Id)
        {
            try
            {
                CostCalculationGarment model = Facade.ReadByIdAsync(Id).Result;
                CostCalculationGarmentViewModel viewModel = Mapper.Map<CostCalculationGarmentViewModel>(model);

                int timeoffsset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);

                CostCalculationGarmentPdfTemplate PdfTemplate = new CostCalculationGarmentPdfTemplate();
                MemoryStream stream = PdfTemplate.GeneratePdfTemplate(viewModel, timeoffsset);

                return new FileStreamResult(stream, "application/pdf")
                {
                    FileDownloadName = "Cost Calculation Export Garment " + viewModel.RO_Number + ".pdf"
                };
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("budget/{Id}")]
        public async Task<IActionResult> GetBudget([FromRoute]int Id)
        {
            try
            {
                Service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;
                Service.Token = Request.Headers["Authorization"].First().Replace("Bearer ", "");

                //await Service.GeneratePO(Id);
                CostCalculationGarment model = Facade.ReadByIdAsync(Id).Result;
                CostCalculationGarmentViewModel viewModel = Mapper.Map<CostCalculationGarmentViewModel>(model);

                int timeoffsset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);

                CostCalculationGarmentBudgetPdfTemplate PdfTemplate = new CostCalculationGarmentBudgetPdfTemplate();
                MemoryStream stream = PdfTemplate.GeneratePdfTemplate(viewModel, timeoffsset);

                return new FileStreamResult(stream, "application/pdf")
                {
                    FileDownloadName = "Budget Export Garment " + viewModel.RO_Number + ".pdf"
                };
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
