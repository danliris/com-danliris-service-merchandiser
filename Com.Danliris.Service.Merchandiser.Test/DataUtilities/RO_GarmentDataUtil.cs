using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Test.DataUtilities
{
   public class RO_GarmentDataUtil
    {

        private readonly RO_GarmentService Service;

        public RO_GarmentDataUtil(RO_GarmentService service)
        {
            Service = service;
        }

        public RO_Garment GetRO_GarmentModel()
        {
        
            RO_Garment TestData = new RO_Garment()
            {
                CostCalculationGarmentId = 1,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){Active = true, Code ="CodeTest", Id=1}
                    }

                } },
            };
            return TestData;
        }


        public RO_GarmentViewModel GetRO_GarmentViewModel()
        {
            return new RO_GarmentViewModel()
            {
              

            };
        }
    }
}
}
