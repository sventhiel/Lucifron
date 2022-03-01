using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteTypes
    {
        [JsonProperty("resourceTypeGeneral")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteResourceType ResourceTypeGeneral { get; set; }
    }

    public enum DataCiteResourceType
    {
        [EnumMember(Value = "Dataset")]
        Dataset
    }
}