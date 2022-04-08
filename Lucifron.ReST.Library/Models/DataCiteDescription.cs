using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteDescription
    {
        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("descriptionType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteDescriptionType? DescriptionType { get; set; }

        [JsonConstructor]
        protected DataCiteDescription()
        { }

        public DataCiteDescription(string description, string lang = null, DataCiteDescriptionType? descriptionType = null)
        {
            Description = description;

            if (lang != null)
                Language = lang;

            if (descriptionType != null)
                DescriptionType = descriptionType;
        }
    }

    public enum DataCiteDescriptionType
    {
        [EnumMember(Value = "Abstract")]
        Abstract = 1,

        [EnumMember(Value = "Methods")]
        Methods = 2
    }
}