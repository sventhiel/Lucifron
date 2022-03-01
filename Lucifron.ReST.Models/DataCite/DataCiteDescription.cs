using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteDescription
    {
        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("descriptionType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteDescriptionType DescriptionType { get; set; }
    }

    public enum DataCiteDescriptionType
    {
        [EnumMember(Value = "Abstract")]
        Abstract,

        [EnumMember(Value = "Methods")]
        Methods
    }
}