//using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Danliris.Service.Merchandiser.Lib.Models
{
    public class RO_Garment : StandardEntity, IValidatableObject
    {
        public int CostCalculationGarmentId { get; set; }
        public virtual CostCalculationGarment CostCalculationGarment { get; set; }
        public string Code { get; set; }
        public ICollection<RO_Garment_SizeBreakdown> RO_Garment_SizeBreakdowns { get; set; }
        public string Instruction { get; set; }
        public int Total { get; set; }
        [NotMapped]
        public List<string> ImagesFile { get; set; }
         public string ImagesPath { get; set; }
        public string ImagesName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
