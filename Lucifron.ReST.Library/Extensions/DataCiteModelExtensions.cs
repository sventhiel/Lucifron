using Lucifron.ReST.Library.Models;
using System.Collections.Generic;
using DataAnnotationsValidator;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Extensions
{
    public static class DataCiteModelExtensions
    {
        public static bool Validate(this DataCiteModel model, out List<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            var validator = new DataAnnotationsValidator.DataAnnotationsValidator();

            return validator.TryValidateObjectRecursive<DataCiteModel>(model, results);
        }
    }
}