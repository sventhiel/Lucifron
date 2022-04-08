using Lucifron.ReST.Library.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lucifron.ReST.Library.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class DataCiteModel
    {
        [JsonProperty("data.doi")]
        public string DOI { get; set; }

        [JsonProperty("data.attributes.creators")]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("data.attributes.descriptions")]
        public List<DataCiteDescription> Descriptions { get; set; }

        [JsonProperty("data.attributes.subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("data.attributes.titles")]
        public List<DataCiteTitle> Titles { get; set; }

        public DataCiteModel()
        {
            Creators = new List<DataCiteCreator>();
            Descriptions = new List<DataCiteDescription>();
            Subjects = new List<DataCiteSubject>();
            Titles = new List<DataCiteTitle>();
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