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

        public static DataCiteTitle Convert(string title, string lang = null, DataCiteTitleType? titleType = null)
        {
            var dataCiteTitle = new DataCiteTitle()
            {
                Title = title
            };

            if (lang != null)
                dataCiteTitle.Language = lang;

            if (titleType != null)
                dataCiteTitle.TitleType = titleType;

            return dataCiteTitle;
        }
    }

    public enum DataCiteTitleType
    {
        [EnumMember(Value = "AlternativeTitle")]
        AlternativeTitle,

        [EnumMember(Value = "Subtitle")]
        Subtitle,

        [EnumMember(Value = "TranslatedTitle")]
        TranslatedTitle,

        [EnumMember(Value = "Other")]
        Other
    }
}