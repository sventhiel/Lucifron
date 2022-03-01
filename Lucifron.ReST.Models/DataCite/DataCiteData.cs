using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteData
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteType Type { get; set; }

        [JsonProperty("attributes")]
        public DataCiteAttributes Attributes { get; set; }
    }

    public enum DataCiteType
    {
        [EnumMember(Value = "dois")]
        DOIs
    }
}