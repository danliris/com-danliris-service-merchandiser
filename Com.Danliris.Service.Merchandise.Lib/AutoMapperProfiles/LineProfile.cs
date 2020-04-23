using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
   public class LineProfile: Profile
    {
        public LineProfile()
        {
            CreateMap<Line, LineViewModel>()
                .ReverseMap();
        }
    }
}
