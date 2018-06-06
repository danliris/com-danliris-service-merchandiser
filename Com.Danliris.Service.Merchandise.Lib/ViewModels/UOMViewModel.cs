using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class UOMViewModel : BasicOldViewModel, IValidatableObject
    {
        public string code { get; set; }
        public string unit { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.code))
                yield return new ValidationResult("Kode harus diisi", new List<string> { "Code" });

            if (string.IsNullOrWhiteSpace(this.unit))
                yield return new ValidationResult("Nama harus diisi", new List<string> { "Name" });
            else if (int.TryParse(this.unit, out int n))
                yield return new ValidationResult("Satuan hanya berupa huruf", new List<string> { "Name" });
        }
    }
}
