using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
   public class RO_Garment_SizeBreakdownProfile:Profile
    {
        public RO_Garment_SizeBreakdownProfile()
        {
            CreateMap<RO_Garment_SizeBreakdown, RO_Garment_SizeBreakdownViewModel>()
               .ReverseMap();
        }
    }
}
