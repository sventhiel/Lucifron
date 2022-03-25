using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteAttributes
    {
        #region required
        [JsonProperty("doi")]
        public string DOI { get; set; }

        [JsonProperty("event", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public DataCiteEventType Event { get; set; }

        [JsonProperty("creators", Required = Required.Always)]
        [Required]
        [MinLength(1)]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("titles", Required = Required.Always)]
        [Required]
        [MinLength(1)]
        public List<DataCiteTitle> Titles { get; set; }

        [JsonProperty("publisher", Required = Required.Always)]
        [Required]
        public string Publisher { get; set; }

        [JsonProperty("publicationYear", Required = Required.Always)]
        [Required]
        public int PublicationYear { get; set; }

        [JsonProperty("url", Required = Required.Always)]
        [Required]
        public string URL { get; set; }

        [JsonProperty("types", Required = Required.Always)]
        [Required]
        public DataCiteTypes Types { get; set; }

        #endregion

        #region recommended / optional

        [JsonProperty("subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("dates")]
        public List<DataCiteDate> Dates { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("descriptions")]
        public List<DataCiteDescription> Descriptions { get; set; }

        #endregion

        [JsonConstructor]
        public DataCiteAttributes()
        {
            Creators = new List<DataCiteCreator>();
            Descriptions = new List<DataCiteDescription>();
            Subjects = new List<DataCiteSubject>();
            Titles = new List<DataCiteTitle>();
        }
    }

    public enum DataCiteEventType
    {
        [EnumMember(Value = "publish")]
        Publish = 1,

        [EnumMember(Value = "register")]
        Register = 2,

        [EnumMember(Value = "hide")]
        Hide = 3
    }
}