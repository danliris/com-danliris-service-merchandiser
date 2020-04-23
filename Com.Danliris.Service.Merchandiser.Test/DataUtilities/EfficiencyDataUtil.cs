using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Test.DataUtilities
{
    class EfficiencyDataUtil
    {

        private readonly EfficiencyService Service;

        public EfficiencyDataUtil(EfficiencyService service)
        {
            Service = service;
        }

        public Efficiency GetEfficiencyModel()
        {
            Efficiency TestData = new Efficiency()
            {
                Name = "name",
                Code = "anycode",
                InitialRange = 10,
                FinalRange = 20,
              

            };

            return TestData;
        }


        public EfficiencyViewModel GetEfficiencyViewModel()
        {
            return new EfficiencyViewModel()
            {
                Name = "name",
                InitialRange = 1,
                FinalRange = 1,
                Value = 1
            };
        }
    }
}
