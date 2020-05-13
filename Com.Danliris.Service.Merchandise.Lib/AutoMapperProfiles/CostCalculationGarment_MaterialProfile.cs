using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
   public class CostCalculationGarment_MaterialProfile:Profile
    {
       public CostCalculationGarment_MaterialProfile()
        {
            CreateMap<CostCalculationGarment_Material, CostCalculationGarment_MaterialViewModel>()
                
                .ForPath(p => p.Code, opt => opt.MapFrom(m => m.Code))
                .ForPath(p => p.Category._id, opt => opt.MapFrom(m => m.CategoryId))
                .ForPath(p => p.Category.name, opt => opt.MapFrom(m => m.CategoryName))
                 .ForPath(p => p._LastModifiedUtc, opt => opt.MapFrom(m => m.LastModifiedUtc))
                 .ForPath(p => p.Product._id, opt => opt.MapFrom(m => m.ProductId))
                 .ForPath(p => p.Product.code, opt => opt.MapFrom(m => m.ProductCode))
                 .ForPath(p => p.Price, opt => opt.MapFrom(m => m.Price))
                 .ForPath(p => p.Total, opt => opt.MapFrom(m => m.Total))
                 .ForPath(p => p.Description, opt => opt.MapFrom(m => m.Description))
                 .ForPath(p => p.Quantity, opt => opt.MapFrom(m => m.Quantity))
                 .ForPath(p => p.UOMPrice._id, opt => opt.MapFrom(m => m.UOMPriceId))
                 .ForPath(p => p.UOMPrice.unit, opt => opt.MapFrom(m => m.UOMPriceName))
                 .ForPath(p => p.UOMQuantity._id, opt => opt.MapFrom(m => m.UOMQuantityId))
                 .ForPath(p => p.UOMQuantity.unit, opt => opt.MapFrom(m => m.UOMQuantityName))
                .ReverseMap();
        }
    }
}
