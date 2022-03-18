using Lucifron.ReST.Library.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Extensions
{
    public static class DataCiteModelExtensions
    {
        public static bool Validate(this DataCiteModel model, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(model, new ValidationContext(model), results, true);
        }
    }
}