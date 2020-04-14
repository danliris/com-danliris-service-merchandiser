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
     where IFacade : IBaseFacade<TModel, TViewModel>
    {
        protected IIdentityService IdentityService;
        protected readonly IValidateService ValidateService;
        protected readonly IFacade Facade;
        protected readonly string ApiVersion;

        public BasicController(IIdentityService identityService, IValidateService validateService, IFacade facade, string apiVersion)
        {
            this.IdentityService = identityService;
            this.ValidateService = validateService;
            this.Facade = facade;
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

                var read = Facade.ReadModel(Page, Size, Order, Select, Keyword, Filter);

                //Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> Data = Facade.Read(page, size, order, select, keyword, filter);
                //List<TViewModel> DataVM = Mapper.Map<List<TViewModel>>(read.Data);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok<TModel, TViewModel>(read.Item1, Facade.MapToViewModel, Page, Size, read.Item2, read.Item1.Count, read.Item3, read.Item4);
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

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TModel model = await Facade.ReadModelById(id);

                if (model == null)
                {
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, General.NOT_FOUND_STATUS_CODE, General.NOT_FOUND_MESSAGE)
                        .Fail();
                    return NotFound(Result);
                }
                else
                {
                    //TViewModel viewModel = Mapper.Map<TViewModel>(model);
                    Dictionary<string, object> Result =
                        new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                        .Ok(model, Facade.MapToViewModel);
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

                TModel model = Facade.MapToModel(ViewModel);

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
                //TModel Model = Mapper.Map<TModel>(ViewModel);
                //TModel Model = Facade.MapToModel(ViewModel);
                await Facade.UpdateModel(Id, model);

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

                //TModel model = Mapper.Map<TModel>(ViewModel);
                TModel model = Facade.MapToModel(ViewModel);
                await Facade.CreateModel(model);

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
                await Facade.DeleteModel(Id);

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