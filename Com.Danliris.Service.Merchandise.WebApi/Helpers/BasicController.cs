using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Com.Moonlay.Models;
using System.ComponentModel.DataAnnotations;
using Com.Moonlay.NetCore.Lib.Service;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Exceptions;
using System.Linq;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities.BaseClass;

namespace Com.Danliris.Service.Merchandiser.WebApi.Helpers
{
    public abstract class BasicController<TModel, TViewModel, IFacade> : Controller
     where TModel : StandardEntity, IValidatableObject
     where TViewModel : BaseViewModel, IValidatableObject
     where IFacade : IBaseFacade<TModel>
    {
        protected IIdentityService IdentityService;
        protected readonly IValidateService ValidateService;
        protected readonly IFacade Facade;
        protected readonly IMapper Mapper;
        protected readonly string ApiVersion;

        public BasicController(IIdentityService identityService, IValidateService validateService, IFacade facade, IMapper mapper, string apiVersion)
        {
            this.IdentityService = identityService;
            this.ValidateService = validateService;
            this.Facade = facade;
            this.Mapper = mapper;
            this.ApiVersion = apiVersion;
        }

        protected void ValidateUser()
        {
            IdentityService.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;
            IdentityService.Token = Request.Headers["Authorization"].First().Replace("Bearer ", "");
        }

        private void ValidateViewModel(TViewModel viewModel)
        {
            ValidateService.Validate(viewModel);
        }

        [HttpGet]
        public virtual IActionResult Get(int Page = 1, int Size = 25, string Order = "{}", [Bind(Prefix = "Select[]")]List<string> Select = null, string Keyword = null, string Filter = "{}")
        {

            try
            {
                ValidateUser();

                ReadResponse<TModel> read = Facade.Read(Page, Size, Order, Select, Keyword, Filter);

                //Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> Data = Facade.Read(page, size, order, select, keyword, filter);
                List<TViewModel> DataVM = Mapper.Map<List<TViewModel>>(read.Data);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok<TViewModel>(Mapper, DataVM, Page, Size, read.Count, DataVM.Count, read.Order, read.Selected);
                return Ok(Result);

            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("{Id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TModel model = await Facade.ReadByIdAsync(Id);

                if (model == null)
                {
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, General.NOT_FOUND_STATUS_CODE, General.NOT_FOUND_MESSAGE)
                        .Fail();
                    return NotFound(Result);
                }
                else
                {

                    //return Ok(new
                    //{
                    //    apiVersion = ApiVersion,
                    //    statusCode = General.OK_STATUS_CODE,
                    //    message = General.OK_MESSAGE,
                    //    data = model,
                    //});

                    TViewModel viewModel = Mapper.Map<TViewModel>(model);
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                        .Ok<TViewModel>(Mapper, viewModel);
                    return Ok(Result);

                }
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromRoute] int Id, [FromBody] TViewModel ViewModel)
        {
            try
            {
                ValidateViewModel(ViewModel);
                ValidateUser();

                TModel model = Mapper.Map<TModel>(ViewModel);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (Id != ViewModel.Id)
                {
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, General.BAD_REQUEST_STATUS_CODE, General.BAD_REQUEST_MESSAGE)
                        .Fail();
                    return BadRequest(Result);
                }
                TModel Model = Mapper.Map<TModel>(ViewModel);
                await Facade.UpdateAsync(Id, model);

                return NoContent();
            }
            //catch (ServiceValidationException e)
            //{
            //    Dictionary<string, object> Result =
            //        new ResultFormatter(ApiVersion, General.BAD_REQUEST_STATUS_CODE, General.BAD_REQUEST_MESSAGE)
            //        .Fail(e);
            //    return BadRequest(Result);
            //}
            catch (DbUpdateConcurrencyException e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> Post([FromBody] TViewModel ViewModel)
        {
            try
            {
                ValidateUser();
                ValidateViewModel(ViewModel);

                TModel model = Mapper.Map<TModel>(ViewModel);
                await Facade.CreateAsync(model);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.CREATED_STATUS_CODE, General.OK_MESSAGE)
                    .Ok();
                return Created(String.Concat(Request.Path, "/", 0), Result);
            }
            //catch (ServiceValidationException e)
            //{
            //    Dictionary<string, object> Result =
            //        new ResultFormatter(ApiVersion, General.BAD_REQUEST_STATUS_CODE, General.BAD_REQUEST_MESSAGE)
            //        .Fail(e);
            //    return BadRequest(Result);
            //}
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpDelete("{Id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ValidateUser();
                await Facade.DeleteAsync(Id);

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