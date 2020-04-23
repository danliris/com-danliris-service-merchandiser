using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.AutoMapperProfiles
{
  public  class RO_Garment_SizeBreakdown_DetailProfile:Profile
    {
        public RO_Garment_SizeBreakdown_DetailProfile()
        {
            CreateMap<RO_Garment_SizeBreakdown_Detail, RO_Garment_SizeBreakdown_DetailViewModel>().ReverseMap();
        }
    }
}
