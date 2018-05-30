using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class ArticleColorViewModel : BasicViewModel, IValidatableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                yield return new ValidationResult("Nama harus diisi", new List<string> { "Name" });
        }
    }
}
