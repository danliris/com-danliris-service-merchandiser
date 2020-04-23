using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
  public  class RateProfile :Profile
    {
        public RateProfile()
        {
            CreateMap<Rate, RateViewModel>()
          .ForPath(p => p.Code, opt => opt.MapFrom(m => m.Code))
          .ForPath(p => p.Name, opt => opt.MapFrom(m => m.Name))
          .ForPath(p => p.Value, opt => opt.MapFrom(m => m.Value))
           .ForPath(p => p.CreatedBy, opt => opt.MapFrom(m => m.CreatedBy))
            .ForPath(p => p.CreatedAgent, opt => opt.MapFrom(m => m.CreatedAgent))
          .ReverseMap();

            CreateMap<CostCalculationGarment, CostCalculationGarmentViewModel>()
          .ForPath(p => p.ConfirmDate, opt => opt.MapFrom(m => m.ConfirmDate))
          .ReverseMap();
        }
    }
}
