using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteAttributes
    {
        [JsonProperty("doi")]
        [JsonRequired]
        public string DOI { get; set; }

        [JsonProperty("event")]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonRequired]
        public DataCiteEventType Event { get; set; }

        [JsonProperty("publisher")]
        [JsonRequired]
        public string Publisher { get; set; }

        [JsonProperty("subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("dates")]
        public List<DataCiteDate> Dates { get; set; }

        [JsonProperty("publicationYear")]
        [JsonRequired]
        public int PublicationYear { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("descriptions")]
        public List<DataCiteDescription> Descriptions { get; set; }

        [JsonProperty("creators")]
        [JsonRequired]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("titles")]
        [JsonRequired]
        public List<DataCiteTitle> Titles { get; set; }

        [JsonProperty("types")]
        [JsonRequired]
        public DataCiteTypes Types { get; set; }

        [JsonProperty("url")]
        [JsonRequired]
        public string URL { get; set; }
    }

    public enum DataCiteEventType
    {
        [EnumMember(Value = "publish")]
        Publish,

        [EnumMember(Value = "register")]
        Register,

        [EnumMember(Value = "hide")]
        Hide
    }
}