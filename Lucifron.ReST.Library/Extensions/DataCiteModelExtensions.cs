using Lucifron.ReST.Library.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Extensions
{
    public static class DataCiteModelExtensions
    {
        public static bool Validate(this CreateDataCiteModel model, out List<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            var validator = new DataAnnotationsValidator.DataAnnotationsValidator();

            return validator.TryValidateObjectRecursive<CreateDataCiteModel>(model, results);
        }

        public static string Serialize(this CreateDataCiteModel model)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            return JsonConvert.SerializeObject(model, jsonSettings);
        }
    }
}