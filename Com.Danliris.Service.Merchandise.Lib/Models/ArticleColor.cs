using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.Models
{
    public class ArticleColor : StandardEntity, IValidatableObject
    {
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
