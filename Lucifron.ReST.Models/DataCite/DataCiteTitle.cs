using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteTitle
    {
        [JsonProperty("title")]
        [JsonRequired]
        public string Title { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("titleType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteTitleType TitleType { get; set; }
    }

    public enum DataCiteTitleType
    {
        [EnumMember(Value = "Subtitle")]
        Subtitle,
    }
}