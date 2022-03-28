using Lucifron.ReST.Library.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Extensions
{
    public static class DataCiteModelExtensions
    {
        public static DataCiteData Data(this DataCiteModel model)
        {
            if(model.Data == null)
                model.Data = new DataCiteData();

            return model.Data;
        }

        public static bool Validate(this DataCiteModel model, out List<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            var validator = new DataAnnotationsValidator.DataAnnotationsValidator();

            return validator.TryValidateObjectRecursive<DataCiteModel>(model, results);
        }

        public static string Serialize(this DataCiteModel model)
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