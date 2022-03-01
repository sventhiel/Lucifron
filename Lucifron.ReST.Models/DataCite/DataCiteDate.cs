using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteDate
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dateType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteDateType DateType { get; set; }
    }

    public enum DataCiteDateType
    {
        [EnumMember(Value = "Issued")]
        Issued
    }
}