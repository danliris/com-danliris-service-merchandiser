using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class GarmentProductViewModel : IValidatableObject
    {
        public string _id { get; set; }
        public string code { get; set; }
        public string composition { get; set; }
        public string construction { get; set; }
        public string yarn { get; set; }
        public string width { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
