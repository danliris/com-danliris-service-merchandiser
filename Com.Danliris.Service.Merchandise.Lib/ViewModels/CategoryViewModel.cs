using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class CategoryViewModel : BasicOldViewModel, IValidatableObject
    {
        public string code { get; set; }
        public string name { get; set; }
        public string SubCategory { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.name))
                yield return new ValidationResult("Nama Kategori harus diisi", new List<string> { "Name" });
        }
    }
}
