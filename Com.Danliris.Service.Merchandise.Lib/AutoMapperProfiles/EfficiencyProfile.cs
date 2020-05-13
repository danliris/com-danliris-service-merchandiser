using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
    public class EfficiencyProfile : Profile
    {
      public  EfficiencyProfile()
        {
            CreateMap<Efficiency, EfficiencyViewModel>()
           .ForPath(p => p.Code, opt => opt.MapFrom(m => m.Code))
           .ForPath(p => p.Name, opt => opt.MapFrom(m => m.Name))
           .ForPath(p => p.InitialRange, opt => opt.MapFrom(m => m.InitialRange))
           .ForPath(p => p.FinalRange, opt => opt.MapFrom(m => m.FinalRange))
           .ForPath(p => p.Value, opt => opt.MapFrom(m => m.Value))
           .ReverseMap();
        }
    }
}
