using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services.AzureStorage;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using System.Linq;
using Newtonsoft.Json;
using Com.Moonlay.NetCore.Lib;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Moonlay.Models;

namespace Com.Danliris.Service.Merchandiser.Lib.Services
{
    public class RO_GarmentService : BasicService<MerchandiserDbContext, RO_Garment>, IMap<RO_Garment, RO_GarmentViewModel>, IROGarment
    {
        private readonly IAzureImageService _azureImageService;
        private readonly ICostCalculationGarments _costCalculationGarmentService;
        private readonly ICostCalculationGarment_Material _costCalculationGarment_MaterialService;
        protected IIdentityService IdentityService;

        public RO_GarmentService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _azureImageService = serviceProvider.GetService<IAzureImageService>();
            _costCalculationGarmentService = serviceProvider.GetService<ICostCalculationGarments>();
            _costCalculationGarment_MaterialService = serviceProvider.GetService<ICostCalculationGarment_Material>();
            IdentityService = serviceProvider.GetService<IIdentityService>();
        }

        //private AzureImageService AzureImageService
        //{
        //    get { return this.ServiceProvider.GetService<AzureImageService>(); }
        //}

        private RO_Garment_SizeBreakdownService RO_Garment_SizeBreakdownService
        {
            get
            {
                RO_Garment_SizeBreakdownService service = this.ServiceProvider.GetService<RO_Garment_SizeBreakdownService>();
                service.Username = this.Username;
                return service;
            }
        }

        //private CostCalculationGarmentService CostCalculationGarmentService
        //{
        //    get
        //    {
        //        CostCalculationGarmentService service = this.ServiceProvider.GetService<ICostCalculationGarments>();
        //        service.Username = this.Username;
        //        return service;
        //    }
        //}

        //private CostCalculationGarment_MaterialService CostCalculationGarment_MaterialService
        //{
        //    get
        //    {
        //        CostCalculationGarment_MaterialService service = this.ServiceProvider.GetService<CostCalculationGarment_MaterialService>();
        //        service.Username = this.Username;
        //        return service;
        //    }
        //}

        public override Tuple<List<RO_Garment>, int, Dictionary<string, string>, List<string>> ReadModel(int Page = 1, int Size = 25, string Order = "{}", List<string> Select = null, string Keyword = null, string Filter = "{}")
        {
            IQueryable<RO_Garment> Query = this.DbContext.RO_Garments;

            List<string> SearchAttributes = new List<string>()
                {
                    "Code"
                };
            Query = ConfigureSearch(Query, SearchAttributes, Keyword);

            Dictionary<string, object> FilterDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(Filter);
            Query = ConfigureFilter(Query, FilterDictionary);

            List<string> SelectedFields = new List<string>()
                {
                    "Id", "Code", "CostCalculationGarment", "Total"
                };
            Query = Query
            .Select(ro => new RO_Garment
            {
                Id = ro.Id,
                Code = ro.Code,
                CostCalculationGarment = new CostCalculationGarment()
                {
                    Id = ro.CostCalculationGarment.Id,
                    Code = ro.CostCalculationGarment.Code,
                    RO_Number = ro.CostCalculationGarment.RO_Number,
                    Article = ro.CostCalculationGarment.Article,
                    Convection = ro.CostCalculationGarment.Convection,
                    
                    //LineId = ro.CostCalculationGarment.LineId,
                    //LineName = ro.CostCalculationGarment.LineName,
                },

                Total = ro.Total,
                LastModifiedUtc = ro.LastModifiedUtc
            });;

            Dictionary<string, string> OrderDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Order);
            Query = ConfigureOrder(Query, OrderDictionary);

            Pageable<RO_Garment> pageable = new Pageable<RO_Garment>(Query, Page - 1, Size);
            List<RO_Garment> Data = pageable.Data.ToList<RO_Garment>();
            int TotalData = pageable.TotalCount;

            return Tuple.Create(Data, TotalData, OrderDictionary, SelectedFields);
        }

        public override async Task<int> CreateModel(RO_Garment Model)
        {
            CostCalculationGarment costCalculationGarment = Model.CostCalculationGarment;
           // Model.CostCalculationGarment = null;

            int created = await this.CreateAsync(Model);

            Model.ImagesPath = await _azureImageService.UploadMultipleImage(Model.GetType().Name, Model.Id, Model.CreatedUtc, Model.ImagesFile, Model.ImagesPath);

            await this.UpdateAsync(Model.Id, Model);

            costCalculationGarment.RO_GarmentId = Model.Id;
            await _costCalculationGarmentService.UpdateAsync(costCalculationGarment.Id, costCalculationGarment);

            return created;
        }

        public override void OnCreating(RO_Garment model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));

            if (model.RO_Garment_SizeBreakdowns.Count > 0)
            {
                foreach (RO_Garment_SizeBreakdown RO_Garment_SizeBreakdown in model.RO_Garment_SizeBreakdowns)
                {
                    this.RO_Garment_SizeBreakdownService.Creating(RO_Garment_SizeBreakdown);
                }
            }

            base.OnCreating(model);
        }

        public override async Task<RO_Garment> ReadModelById(int id)
        {
            RO_Garment read = await this.DbSet
                .Where(d => d.Id.Equals(id) && d.IsDeleted.Equals(false))
                .Include(d => d.RO_Garment_SizeBreakdowns)
                    .ThenInclude(sb => sb.RO_Garment_SizeBreakdown_Details)
                .Include(d => d.CostCalculationGarment)
                    .ThenInclude(ccg => ccg.CostCalculationGarment_Materials)
                .FirstOrDefaultAsync();

            read.CostCalculationGarment.ImageFile = await _azureImageService.DownloadImage(read.CostCalculationGarment.GetType().Name, read.CostCalculationGarment.ImagePath);
            read.ImagesFile = await _azureImageService.DownloadMultipleImages(read.GetType().Name, read.ImagesPath);

            return read;
        }

        public override async Task<int> UpdateModel(int Id, RO_Garment Model)
        {
            CostCalculationGarment costCalculationGarment = Model.CostCalculationGarment;
           // Model.CostCalculationGarment = null;

            Model.ImagesPath = await _azureImageService.UploadMultipleImage(Model.GetType().Name, Model.Id, Model.CreatedUtc, Model.ImagesFile, Model.ImagesPath);

            int updated = await this.UpdateAsync(Id, Model);

            costCalculationGarment.RO_GarmentId = Model.Id;
            await _costCalculationGarmentService.UpdateAsync(costCalculationGarment.Id, costCalculationGarment);

            return updated;
        }

        public override void OnUpdating(int id, RO_Garment model)
        {
            HashSet<int> RO_Garment_SizeBreakdowns = new HashSet<int>(this.RO_Garment_SizeBreakdownService.DbSet
                .Where(p => p.RO_GarmentId.Equals(id))
                .Select(p => p.Id));

            foreach (int RO_Garment_SizeBreakdown in RO_Garment_SizeBreakdowns)
            {
                RO_Garment_SizeBreakdown childModel = model.RO_Garment_SizeBreakdowns.FirstOrDefault(prop => prop.Id.Equals(RO_Garment_SizeBreakdown));

                if (childModel == null)
                {
                    this.RO_Garment_SizeBreakdownService.Deleting(RO_Garment_SizeBreakdown);
                }
                else
                {
                    this.RO_Garment_SizeBreakdownService.Updating(RO_Garment_SizeBreakdown, childModel);
                }
            }

            foreach (RO_Garment_SizeBreakdown RO_Garment_SizeBreakdown in model.RO_Garment_SizeBreakdowns)
            {
                if (RO_Garment_SizeBreakdown.Id.Equals(0))
                {
                    this.RO_Garment_SizeBreakdownService.Creating(RO_Garment_SizeBreakdown);
                }
            }

            base.OnUpdating(id, model);
        }

        //public override async Task<int> DeleteModel(int Id)
        //{
        //    RO_Garment deletedImage = await this.GetAsync(Id);
        //    await _azureImageService.RemoveMultipleImage(deletedImage.GetType().Name, deletedImage.ImagesPath);

        //    int deleted = await this.DeleteAsync(Id);

        //    CostCalculationGarment costCalculationGarment = await _costCalculationGarmentService.ReadModelById(deletedImage.CostCalculationGarmentId);
        //    costCalculationGarment.RO_GarmentId = null;
        //    costCalculationGarment.ImageFile = string.IsNullOrWhiteSpace(costCalculationGarment.ImageFile) ? "#" : costCalculationGarment.ImageFile;
        //    await _costCalculationGarmentService.UpdateAsync(costCalculationGarment.Id, costCalculationGarment);

        //    List<CostCalculationGarment_Material> costCalculationGarment_Materials = _costCalculationGarment_MaterialService.DbSet.Where(p => p.CostCalculationGarmentId.Equals(costCalculationGarment.Id)).ToList();
        //    foreach (CostCalculationGarment_Material costCalculationGarment_Material in costCalculationGarment_Materials)
        //    {
        //        costCalculationGarment_Material.Information = null;
        //        await _costCalculationGarment_MaterialService.UpdateModel(costCalculationGarment_Material.Id, costCalculationGarment_Material);
        //    }

        //    return deleted;
        //}

        public override async Task<int> DeleteModel(int Id)
        {
            RO_Garment deletedImage = await this.GetAsync(Id);
            await _azureImageService.RemoveMultipleImage(deletedImage.GetType().Name, deletedImage.ImagesPath);

           int deleted = await this.DeleteAsync(Id);

            CostCalculationGarment costCalculationGarment = await _costCalculationGarmentService.ReadModelById(deletedImage.CostCalculationGarmentId);
            costCalculationGarment.RO_GarmentId = null;
            costCalculationGarment.ImageFile = string.IsNullOrWhiteSpace(costCalculationGarment.ImageFile) ? "#" : costCalculationGarment.ImageFile;
            await _costCalculationGarmentService.UpdateAsync(costCalculationGarment.Id, costCalculationGarment);

            List<CostCalculationGarment_Material> costCalculationGarment_Materials = _costCalculationGarment_MaterialService.DbSet.Where(p => p.CostCalculationGarmentId.Equals(costCalculationGarment.Id)).ToList();
            foreach (CostCalculationGarment_Material costCalculationGarment_Material in costCalculationGarment_Materials)
            {
                costCalculationGarment_Material.Information = null;
                await _costCalculationGarment_MaterialService.UpdateModel(costCalculationGarment_Material.Id, costCalculationGarment_Material);
            }

            return deleted;
        }

        public override void OnDeleting(RO_Garment model)
        {
            HashSet<int> RO_Garment_SizeBreakdowns = new HashSet<int>(this.RO_Garment_SizeBreakdownService.DbSet
                .Where(p => p.RO_GarmentId.Equals(model.Id))
                .Select(p => p.Id));

            foreach (int RO_Garment_SizeBreakdown in RO_Garment_SizeBreakdowns)
            {
                this.RO_Garment_SizeBreakdownService.Deleting(RO_Garment_SizeBreakdown);
            }

            base.OnDeleting(model);
        }

        public RO_GarmentViewModel MapToViewModel(RO_Garment model)
        {
            RO_GarmentViewModel viewModel = new RO_GarmentViewModel();
            PropertyCopier<RO_Garment, RO_GarmentViewModel>.Copy(model, viewModel);
            viewModel.ImagesPath = model.ImagesPath != null ? JsonConvert.DeserializeObject<List<string>>(model.ImagesPath) : null;

            viewModel.CostCalculationGarment = _costCalculationGarmentService.MapToViewModel(model.CostCalculationGarment);
            viewModel.ImagesName = model.ImagesName != null ? JsonConvert.DeserializeObject<List<string>>(model.ImagesName) : new List<string>();

            viewModel.RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdownViewModel>();
            if (model.RO_Garment_SizeBreakdowns != null)
            {
                foreach (RO_Garment_SizeBreakdown sizeBreakdown in model.RO_Garment_SizeBreakdowns)
                {
                    RO_Garment_SizeBreakdownViewModel sizeBreakdownVM = this.RO_Garment_SizeBreakdownService.MapToViewModel(sizeBreakdown);
                    viewModel.RO_Garment_SizeBreakdowns.Add(sizeBreakdownVM);
                }
            }

            return viewModel;
        }

        public RO_Garment MapToModel(RO_GarmentViewModel viewModel)
        {
            RO_Garment model = new RO_Garment();
            PropertyCopier<RO_GarmentViewModel, RO_Garment>.Copy(viewModel, model);
            model.ImagesPath = viewModel.ImagesPath != null ? JsonConvert.SerializeObject(viewModel.ImagesPath) : null;

           // model.CostCalculationGarmentId = viewModel.CostCalculationGarment.Id;
            model.CostCalculationGarment = _costCalculationGarmentService.MapToModel(viewModel.CostCalculationGarment);
            model.ImagesName = JsonConvert.SerializeObject(viewModel.ImagesName);

            model.RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>();
            foreach (RO_Garment_SizeBreakdownViewModel sizeBreakdownVM in viewModel.RO_Garment_SizeBreakdowns)
            {
                RO_Garment_SizeBreakdown sizeBreakdown = this.RO_Garment_SizeBreakdownService.MapToModel(sizeBreakdownVM);
                model.RO_Garment_SizeBreakdowns.Add(sizeBreakdown);
            }

            return model;
        }

        public Task<int> PostRO(List<long> listId)
        {
           
             throw new NotImplementedException();
        }

        public Task<int> UnpostRO(long id)
        {
            throw new NotImplementedException();
        }

     
        public new async Task<int> CreateAsync(RO_Garment model)
        {
            do
            {
                model.Code = Code.Generate();
            }
            while (this.DbSet.Any(d => d.Code.Equals(model.Code)));

        
            model.ImagesPath =await _azureImageService.UploadMultipleImage(model.GetType().Name, model.Id, model.CreatedUtc, model.ImagesFile, model.ImagesPath);

          

            if (model.CostCalculationGarment.CostCalculationGarment_Materials.Count > 0)
            {
                foreach (var costCalculationGarment_Material in model.CostCalculationGarment.CostCalculationGarment_Materials)
                {
                    
                    EntityExtension.FlagForCreate(costCalculationGarment_Material, IdentityService.Username, UserAgent);

                }
            }
            

            EntityExtension.FlagForCreate(model.CostCalculationGarment, IdentityService.Username, UserAgent);

            if (model.RO_Garment_SizeBreakdowns.Count > 0)
            {

                foreach (RO_Garment_SizeBreakdown RO_Garment_SizeBreakdown in model.RO_Garment_SizeBreakdowns)
                {
                    

                    EntityExtension.FlagForCreate(RO_Garment_SizeBreakdown, IdentityService.Username, UserAgent);
                    foreach (var RO_Garment_SizeBreakdown_Detail in RO_Garment_SizeBreakdown.RO_Garment_SizeBreakdown_Details)
                    {
                        EntityExtension.FlagForCreate(RO_Garment_SizeBreakdown_Detail, IdentityService.Username, UserAgent);
                    }
                }
            }


            EntityExtension.FlagForCreate(model, IdentityService.Username, UserAgent);
           
            this.DbSet.Add(model);
            return await this.DbContext.SaveChangesAsync();
        }


        public new async Task<int> DeleteAsync(int Id)
        {

            RO_Garment deletedImage = await this.GetAsync(Id);
            await _azureImageService.RemoveMultipleImage(deletedImage.GetType().Name, deletedImage.ImagesPath);

           // int deleted = await this.DeleteAsync(Id);

            CostCalculationGarment costCalculationGarment = await _costCalculationGarmentService.ReadModelById(deletedImage.CostCalculationGarmentId);
            costCalculationGarment.RO_GarmentId = null;
            costCalculationGarment.ImageFile = string.IsNullOrWhiteSpace(costCalculationGarment.ImageFile) ? "#" : costCalculationGarment.ImageFile;
            await _costCalculationGarmentService.UpdateAsync(costCalculationGarment.Id, costCalculationGarment);

            List<CostCalculationGarment_Material> costCalculationGarment_Materials = _costCalculationGarment_MaterialService.DbSet.Where(p => p.CostCalculationGarmentId.Equals(costCalculationGarment.Id)).ToList();
            foreach (CostCalculationGarment_Material costCalculationGarment_Material in costCalculationGarment_Materials)
            {
                costCalculationGarment_Material.Information = null;
                await _costCalculationGarment_MaterialService.UpdateModel(costCalculationGarment_Material.Id, costCalculationGarment_Material);
            }

            //await this.DeleteModel(Id);
            return await this.DbContext.SaveChangesAsync();
        }

        
        public ReadResponse<RO_Garment> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            var dataModel = ReadModel(page, size, order, select, keyword, filter);


            return new ReadResponse<RO_Garment>(dataModel.Item1, dataModel.Item2, dataModel.Item3, dataModel.Item4);
        }

        public async Task<RO_Garment> ReadByIdAsync(int id)
        {
            return await this.ReadModelById(id);
        }

        public async Task<int> UpdateAsync(int id, RO_Garment model)
        {
            var costCalculationGarment_Materials = model.CostCalculationGarment.CostCalculationGarment_Materials;

            if (costCalculationGarment_Materials.Count>0)
            {
                foreach (var costCalculationGarment_Material in costCalculationGarment_Materials)
                {
                    if (costCalculationGarment_Material.CreatedAgent ==null)
                    {
                        costCalculationGarment_Material.CreatedAgent = "";
                       
                    }

                    if (costCalculationGarment_Material.CreatedBy== null)
                    {
                        costCalculationGarment_Material.CreatedBy = "";

                    }

                    EntityExtension.FlagForUpdate(costCalculationGarment_Material, IdentityService.Username, UserAgent);
                }
            }
           
            EntityExtension.FlagForUpdate(model.CostCalculationGarment, IdentityService.Username, UserAgent);

            if (model.RO_Garment_SizeBreakdowns.Count >= 0)
            {

                foreach (RO_Garment_SizeBreakdown RO_Garment_SizeBreakdown in model.RO_Garment_SizeBreakdowns)
                {
                   if(RO_Garment_SizeBreakdown.CreatedAgent == null)
                    {
                        RO_Garment_SizeBreakdown.CreatedAgent = "";
                    }

                    if (RO_Garment_SizeBreakdown.CreatedBy == null)
                    {
                        RO_Garment_SizeBreakdown.CreatedBy = "";
                    }

                    foreach (var RO_Garment_SizeBreakdown_Detail in RO_Garment_SizeBreakdown.RO_Garment_SizeBreakdown_Details)
                    {
                        if (RO_Garment_SizeBreakdown_Detail.CreatedAgent == null)
                        {
                            RO_Garment_SizeBreakdown_Detail.CreatedAgent = "";
                        }
                        if (RO_Garment_SizeBreakdown_Detail.CreatedBy == null)
                        {
                            RO_Garment_SizeBreakdown_Detail.CreatedBy = "";
                           
                        }
                        EntityExtension.FlagForUpdate(RO_Garment_SizeBreakdown_Detail, IdentityService.Username, UserAgent);
                    }
                    EntityExtension.FlagForUpdate(RO_Garment_SizeBreakdown, IdentityService.Username, UserAgent);
                }
            }

            EntityExtension.FlagForUpdate(model, IdentityService.Username, UserAgent);
            this.DbSet.Update(model);
            return await this.DbContext.SaveChangesAsync();
        }
    }
}
