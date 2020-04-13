using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Newtonsoft.Json;
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
            string encoded_grey = "iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAM1BMVEWAgIB7e3u9vb3ExMTMzMzU1NR4eHja2trs7Oxzc3O5ubn+/v739/fw8PDm5ubi4uLQ0NBf9a+gAAABZklEQVR4nO3dTU7CABRG0RZoC/gD+1+tHTjQOJCQEL30nBV8d/6SN7y8vh3fL5dlNa0On/bf7e63/9XhFtfpFssPx2E6zV+N/9Z8l9N5mObhmY27DRRen77wMP71iIdS2KewT2Gfwj6FfQr71sK9wjaFfQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9h3yYKdwrbFPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2LeJiyGFcQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KezbxBcWhXEK+xT2KexT2KewT2Gfwj6FfQr7FPYp7FPYp7BPYZ/CPoV9CvvWwmn+6xEPpbBPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2KewT2HfWrgobFPYp7BPYZ/CPoV9CvsU9m2j8DQ+s/k8HM+7Z3ZePgCqLRCNpw7OVwAAAABJRU5ErkJggg==";
            string image_grey = "image_grey";

            string[] imagepaths = new string[] { "https://via.placeholder.com/300/09f/fff.png" };
            string imagepath = JsonConvert.SerializeObject(imagepaths);

            RO_Garment TestData = new RO_Garment()
            {
                Id = 1,
                ImagesFile = new List<string>() { encoded_grey },
                ImagesName = "gray_picture.jpg",
                ImagesPath = imagepath,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
              
                CostCalculationGarment = new CostCalculationGarment() { 
                    
                    ImagePath= imagepath,
                    Id =1,
                    Active =true,BuyerId="buyer_id",_IsDeleted=false},
                CostCalculationGarmentId = 1,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Code="code RO_Garment_SizeBreakdowns",
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

        public RO_Garment GetDataForDeleteModel()
        {
            string encoded_grey = "iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAM1BMVEWAgIB7e3u9vb3ExMTMzMzU1NR4eHja2trs7Oxzc3O5ubn+/v739/fw8PDm5ubi4uLQ0NBf9a+gAAABZklEQVR4nO3dTU7CABRG0RZoC/gD+1+tHTjQOJCQEL30nBV8d/6SN7y8vh3fL5dlNa0On/bf7e63/9XhFtfpFssPx2E6zV+N/9Z8l9N5mObhmY27DRRen77wMP71iIdS2KewT2Gfwj6FfQr71sK9wjaFfQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9h3yYKdwrbFPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2LeJiyGFcQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KezbxBcWhXEK+xT2KexT2KewT2Gfwj6FfQr7FPYp7FPYp7BPYZ/CPoV9CvvWwmn+6xEPpbBPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2KewT2HfWrgobFPYp7BPYZ/CPoV9CvsU9m2j8DQ+s/k8HM+7Z3ZePgCqLRCNpw7OVwAAAABJRU5ErkJggg==";
            string image_grey = "image_grey";

            string[] imagepaths = new string[] { "https://via.placeholder.com/300/09f/fff.png" };
            string imagepath = JsonConvert.SerializeObject(imagepaths);

            RO_Garment TestData = new RO_Garment()
            {
                Id = 2,
                ImagesFile = new List<string>() { encoded_grey },
                ImagesName = "gray_picture.jpg",
                ImagesPath = imagepath,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",
                

                CostCalculationGarment = new CostCalculationGarment()
                {

                    ImagePath = imagepath,
                    Id = 2,
                    Active = true,
                    BuyerId = "buyer_id",
                    _IsDeleted = false,

                },
                CostCalculationGarmentId = 1,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Code="code RO_Garment_SizeBreakdowns",

                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){

                            Id=2,
                            Active = true,
                            Code ="CodeTest"}
                    }

                } },
            };
            return TestData;
        }


        public RO_Garment GetDataForReadModel()
        {
            string encoded_grey = "iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAM1BMVEWAgIB7e3u9vb3ExMTMzMzU1NR4eHja2trs7Oxzc3O5ubn+/v739/fw8PDm5ubi4uLQ0NBf9a+gAAABZklEQVR4nO3dTU7CABRG0RZoC/gD+1+tHTjQOJCQEL30nBV8d/6SN7y8vh3fL5dlNa0On/bf7e63/9XhFtfpFssPx2E6zV+N/9Z8l9N5mObhmY27DRRen77wMP71iIdS2KewT2Gfwj6FfQr71sK9wjaFfQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9h3yYKdwrbFPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2LeJiyGFcQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KezbxBcWhXEK+xT2KexT2KewT2Gfwj6FfQr7FPYp7FPYp7BPYZ/CPoV9CvvWwmn+6xEPpbBPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2KewT2HfWrgobFPYp7BPYZ/CPoV9CvsU9m2j8DQ+s/k8HM+7Z3ZePgCqLRCNpw7OVwAAAABJRU5ErkJggg==";
            string image_grey = "image_grey";

            string[] imagepaths = new string[] { "https://via.placeholder.com/300/09f/fff.png" };
            string imagepath = JsonConvert.SerializeObject(imagepaths);

            RO_Garment TestData = new RO_Garment()
            {
                Id = 21,
                ImagesFile = new List<string>() { encoded_grey },
                ImagesName = "gray_picture.jpg",
                ImagesPath = imagepath,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",

                CostCalculationGarment = new CostCalculationGarment()
                {

                    ImagePath = imagepath,
                    Id = 21,
                    Active = true,
                    BuyerId = "buyer_id",
                    _IsDeleted = false
                },
                CostCalculationGarmentId = 21,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Code="code RO_Garment_SizeBreakdowns",
                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){Active = true, Code ="CodeTest", Id=21}
                    }

                } },
            };
            return TestData;
        }


        public RO_Garment GetDataFor_CreateModel()
        {
            string encoded_grey = "iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAM1BMVEWAgIB7e3u9vb3ExMTMzMzU1NR4eHja2trs7Oxzc3O5ubn+/v739/fw8PDm5ubi4uLQ0NBf9a+gAAABZklEQVR4nO3dTU7CABRG0RZoC/gD+1+tHTjQOJCQEL30nBV8d/6SN7y8vh3fL5dlNa0On/bf7e63/9XhFtfpFssPx2E6zV+N/9Z8l9N5mObhmY27DRRen77wMP71iIdS2KewT2Gfwj6FfQr71sK9wjaFfQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9h3yYKdwrbFPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2LeJiyGFcQr7FPYp7FPYp7BPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KezbxBcWhXEK+xT2KexT2KewT2Gfwj6FfQr7FPYp7FPYp7BPYZ/CPoV9CvvWwmn+6xEPpbBPYZ/CPoV9CvsU9insU9insE9hn8I+hX0K+xT2KexT2KewT2HfWrgobFPYp7BPYZ/CPoV9CvsU9m2j8DQ+s/k8HM+7Z3ZePgCqLRCNpw7OVwAAAABJRU5ErkJggg==";
            string image_grey = "image_grey";

            string[] imagepaths = new string[] { "https://via.placeholder.com/300/09f/fff.png" };
            string imagepath = JsonConvert.SerializeObject(imagepaths);

            RO_Garment TestData = new RO_Garment()
            {
                Id = 22,
                ImagesFile = new List<string>() { encoded_grey },
                ImagesName = "gray_picture.jpg",
                ImagesPath = imagepath,
                Active = true,
                Code = "code test",
                _CreatedAgent = "created agen",
                _CreatedBy = "ade",

                CostCalculationGarment = new CostCalculationGarment()
                {

                    ImagePath = imagepath,
                    Id = 22,
                    Active = true,
                    BuyerId = "buyer_id",
                    _IsDeleted = false
                },
                CostCalculationGarmentId = 22,
                RO_Garment_SizeBreakdowns = new List<RO_Garment_SizeBreakdown>() { new RO_Garment_SizeBreakdown() {
                    Code="code RO_Garment_SizeBreakdowns",
                    Active=true,
                    ColorName ="Red",
                    RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_Detail>()
                    {
                        new RO_Garment_SizeBreakdown_Detail(){Active = true, Code ="CodeTest", Id=22}
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

