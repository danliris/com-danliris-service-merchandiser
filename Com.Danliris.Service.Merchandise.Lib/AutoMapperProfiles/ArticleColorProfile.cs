using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
   public class ArticleColorProfile: Profile
    {
       public ArticleColorProfile()
        {
            CreateMap<ArticleColor, ArticleColorViewModel>()
            //.ForPath(p => p.Name, opt => opt.MapFrom(m => m.Name))
            //.ForPath(p => p.Description, opt => opt.MapFrom(m => m.Description))
            .ReverseMap();
        }
    }
}
