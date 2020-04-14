using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
    public class ArticleColorProfile : Profile
    {
        public ArticleColorProfile()
        {
            CreateMap<ArticleColor, ArticleColorViewModel>()
                .ForPath(d => d.CreatedUtc, opt => opt.MapFrom(s => s._CreatedUtc))
                .ForPath(d => d.CreatedBy, opt => opt.MapFrom(s => s._CreatedBy))
                .ForPath(d => d.CreatedAgent, opt => opt.MapFrom(s => s._CreatedAgent))
                .ForPath(d => d.LastModifiedUtc, opt => opt.MapFrom(s => s._LastModifiedUtc))
                .ForPath(d => d.LastModifiedBy, opt => opt.MapFrom(s => s._LastModifiedBy))
                .ForPath(d => d.LastModifiedAgent, opt => opt.MapFrom(s => s._LastModifiedAgent))
                .ForPath(d => d.IsDeleted, opt => opt.MapFrom(s => s._IsDeleted))
                .ReverseMap();
        }
    }
}
