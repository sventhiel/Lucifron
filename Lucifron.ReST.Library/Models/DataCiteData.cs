using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteData
    {
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public DataCiteType Type { get; set; }

        [JsonProperty("attributes", Required = Required.Always)]
        [Required]
        public DataCiteAttributes Attributes { get; set; }

        [JsonConstructor]
        public DataCiteData()
        {
            Attributes = new DataCiteAttributes();
        }
    }

    public enum DataCiteType
    {
        [EnumMember(Value = "dois")]
        DOIs = 1
    }
}