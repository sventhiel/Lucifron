using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteTitle
    {
        [JsonProperty("title")]
        [Required]
        public string Title { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("titleType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteTitleType? TitleType { get; set; }

        [JsonConstructor]
        protected DataCiteTitle()
        { }

        public DataCiteTitle(string title, string lang = null, DataCiteTitleType? titleType = null)
        {
            Title = title;

            if (lang != null)
                Language = lang;

            if (titleType != null)
                TitleType = titleType;
        }
    }

    public enum DataCiteTitleType
    {
        [EnumMember(Value = "AlternativeTitle")]
        AlternativeTitle = 1,

        [EnumMember(Value = "Subtitle")]
        Subtitle = 2,

        [EnumMember(Value = "TranslatedTitle")]
        TranslatedTitle = 3,

        [EnumMember(Value = "Other")]
        Other = 4
    }
}