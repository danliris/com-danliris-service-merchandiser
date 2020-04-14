
using Com.Moonlay.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Com.Danliris.Service.Merchandiser.Lib.Models
{
    public class Rate : StandardEntity, IValidatableObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
