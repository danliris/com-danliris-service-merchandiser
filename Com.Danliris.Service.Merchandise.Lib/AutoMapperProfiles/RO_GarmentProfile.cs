using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
    public class RO_GarmentProfile : Profile
    {
        public RO_GarmentProfile()
        {

          CreateMap<CostCalculationGarment, CostCalculationGarmentViewModel>()
          .ForPath(d => d.Code, opt => opt.MapFrom(m => m.Code))
          .ForPath(d => d.RO_Number, opt => opt.MapFrom(m => m.RO_Number))
          .ForPath(d => d.Article, opt => opt.MapFrom(m => m.Article))

          //Comodity
          .ForPath(p => p.Commodity._id, opt => opt.MapFrom(m => m.ComodityID))
          .ForPath(p => p.Commodity.name, opt => opt.MapFrom(m => m.Commodity))
          .ForPath(d => d.CommodityDescription, opt => opt.MapFrom(m => m.CommodityDescription))


          .ForPath(d => d.CommissionPortion, opt => opt.MapFrom(m => m.CommissionPortion))
          .ForPath(d => d.CommissionRate, opt => opt.MapFrom(m => m.CommissionRate))
          .ForPath(d => d.ConfirmDate, opt => opt.MapFrom(m => m.ConfirmDate))
          .ForPath(p => p.AccessoriesAllowance, opt => opt.MapFrom(m => m.AccessoriesAllowance))
           //Rate
           .ForPath(p => p.Rate.Id, opt => opt.MapFrom(m => m.RateId))
            .ForPath(p => p.Rate.Value, opt => opt.MapFrom(m => m.RateValue))


           //UOM
           .ForPath(p => p.UOM.code, opt => opt.MapFrom(m => m.UOMCode))
           .ForPath(p => p.UOM.unit, opt => opt.MapFrom(m => m.UOMUnit))
           .ForPath(p => p.UOM._id, opt => opt.MapFrom(m => m.UOMID))

           //Buyer
           .ForPath(p => p.Buyer._id, opt => opt.MapFrom(m => m.BuyerId))
           .ForPath(p => p.Buyer.name, opt => opt.MapFrom(m => m.BuyerName))

           //OTL1
           .ForPath(p => p.OTL1.Id, opt => opt.MapFrom(m => m.OTL1Id))
           .ForPath(p => p.OTL1.CalculatedValue, opt => opt.MapFrom(m => m.OTL1CalculatedRate))

           //OTL2
           .ForPath(p => p.OTL2.Id, opt => opt.MapFrom(m => m.OTL2Id))
           .ForPath(p => p.OTL2.CalculatedValue, opt => opt.MapFrom(m => m.OTL2CalculatedRate))

           .ForPath(p => p.Risk, opt => opt.MapFrom(m => m.Risk))
           .ForPath(p => p.FreightCost, opt => opt.MapFrom(m => m.FreightCost))

           .ForPath(p => p.NETFOB, opt => opt.MapFrom(m => m.NETFOB))
           .ForPath(p => p.NETFOBP, opt => opt.MapFrom(m => m.NETFOBP))
           .ForPath(p => p.Insurance, opt => opt.MapFrom(m => m.Insurance))


            .ForPath(p => p.Section, opt => opt.MapFrom(m => m.Section))
            .ForPath(p => p.Quantity, opt => opt.MapFrom(m => m.Quantity))
            .ForPath(p => p.SizeRange, opt => opt.MapFrom(m => m.SizeRange))
            .ForPath(p => p.DeliveryDate, opt => opt.MapFrom(m => m.DeliveryDate))
            .ForPath(p => p.ConfirmDate, opt => opt.MapFrom(m => m.ConfirmDate))
            .ForPath(p => p.LeadTime, opt => opt.MapFrom(m => m.LeadTime))
            .ForPath(p => p.SMV_Cutting, opt => opt.MapFrom(m => m.SMV_Cutting))
            .ForPath(p => p.SMV_Sewing, opt => opt.MapFrom(m => m.SMV_Sewing))
            .ForPath(p => p.SMV_Finishing, opt => opt.MapFrom(m => m.SMV_Finishing))
            .ForPath(p => p.SMV_Total, opt => opt.MapFrom(m => m.SMV_Total))
            .ForPath(p => p.ImageFile, opt => opt.MapFrom(m => m.ImageFile))
            .ForPath(p => p.ImagePath, opt => opt.MapFrom(m => m.ImagePath))
          .ReverseMap();

            CreateMap<RO_Garment_SizeBreakdown, RO_Garment_SizeBreakdownViewModel>()
            .ForPath(d => d.Code, opt => opt.MapFrom(m => m.Code))
            .ForPath(d => d.Total, opt => opt.MapFrom(m => m.Total))
            .ReverseMap();


            CreateMap<RO_Garment, RO_GarmentViewModel>()
            .ForPath(p => p.CostCalculationGarment.Id, opt => opt.MapFrom(m => m.CostCalculationGarmentId))
            .ForPath(p => p.Code, opt => opt.MapFrom(m => m.Code))
            .ForPath(p => p.Instruction, opt => opt.MapFrom(m => m.Instruction))
            .ForPath(p => p.Total, opt => opt.MapFrom(m => m.Total))
            .ForPath(p => p.CostCalculationGarment.Buyer.name, opt => opt.MapFrom(m => m.CostCalculationGarment.BuyerName))
            .ForPath(p => p.CostCalculationGarment.Buyer._id, opt => opt.MapFrom(m => m.CostCalculationGarment.BuyerId))
            .ForPath(p => p.CostCalculationGarment.ImageFile, opt => opt.MapFrom(m => m.CostCalculationGarment.ImageFile))
            .ForPath(p => p.CostCalculationGarment.ImagePath, opt => opt.MapFrom(m => m.CostCalculationGarment.ImagePath))
            .ForPath(p => p.CostCalculationGarment.Insurance, opt => opt.MapFrom(m => m.CostCalculationGarment.Insurance))
            .ForPath(p => p.CostCalculationGarment.RO_Number, opt => opt.MapFrom(m => m.CostCalculationGarment.RO_Number))
            .ForPath(p => p.CostCalculationGarment.Section, opt => opt.MapFrom(m => m.CostCalculationGarment.Section))
             .ForPath(p => p.CostCalculationGarment.ConfirmDate, opt => opt.MapFrom(m => m.CostCalculationGarment.ConfirmDate))
             .ForPath(p => p.CostCalculationGarment.Convection, opt => opt.MapFrom(m => m.CostCalculationGarment.Convection))
             .ForPath(p => p.CostCalculationGarment.DeliveryDate, opt => opt.MapFrom(m => m.CostCalculationGarment.DeliveryDate))
             .ForPath(p => p.CostCalculationGarment.Description, opt => opt.MapFrom(m => m.CostCalculationGarment.Description))
             .ForPath(p => p.CostCalculationGarment.SizeRange, opt => opt.MapFrom(m => m.CostCalculationGarment.SizeRange))

             .ForPath(p => p.ImagesFile, opt => opt.MapFrom(m => m.ImagesFile))
            .ForPath(p => p.CostCalculationGarment.Id, opt => opt.MapFrom(m => m.CostCalculationGarmentId))
            .ReverseMap();

            CreateMap<RO_GarmentViewModel, RO_Garment>()
           .BeforeMap((src, dest) => dest.ImagesPath = JsonConvert.SerializeObject(src.ImagesPath))
           .AfterMap((src, dest) => dest.ImagesPath = JsonConvert.SerializeObject(src.ImagesPath))
           .BeforeMap((src, dest) => dest.ImagesName = JsonConvert.SerializeObject(src.ImagesName))
           .AfterMap((src, dest) => dest.ImagesName = JsonConvert.SerializeObject(src.ImagesName));



        }
    }
}
