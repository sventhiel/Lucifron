using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteModel
    {
        [JsonProperty("data", Required = Required.Always)]
        [Required]
        public DataCiteData Data { get; set; }

        [JsonConstructor]
        public DataCiteModel()
        {
            Data = new DataCiteData();
        }

        public static DataCiteModel Deserialize(string json)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            return JsonConvert.DeserializeObject<DataCiteModel>(json, jsonSettings);
        }
    }
}