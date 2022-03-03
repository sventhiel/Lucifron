using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteAttributes
    {
        // Required

        [JsonProperty("doi")]
        public string DOI { get; set; }

        [JsonProperty("event")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteEventType Event { get; set; }

        [JsonProperty("creators")]
        [Required]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("titles")]
        [Required]
        public List<DataCiteTitle> Titles { get; set; }

        [JsonProperty("publisher")]
        [Required]
        public string Publisher { get; set; }

        [JsonProperty("publicationYear")]
        [Required]
        public int PublicationYear { get; set; }

        [JsonProperty("url")]
        [Required]
        public string URL { get; set; }

        [JsonProperty("types")]
        public DataCiteTypes Types { get; set; }

        // Recommended AND Optional















        [JsonProperty("subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("dates")]
        public List<DataCiteDate> Dates { get; set; }



        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("descriptions")]
        public List<DataCiteDescription> Descriptions { get; set; }








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