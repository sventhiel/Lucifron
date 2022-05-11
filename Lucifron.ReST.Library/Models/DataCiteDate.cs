using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteDate
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dateType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteDateType DateType { get; set; }

        [JsonConstructor]
        protected DataCiteDate()
        { }

        public DataCiteDate(string date, DataCiteDateType type)
        {
            Date = date;
            DateType = type;
        }
    }

    public enum DataCiteDateType
    {
        [EnumMember(Value = "Issued")]
        Issued = 1,
        [EnumMember(Value = "Created")]
        Created = 2,
        [EnumMember(Value = "Updated")]
        Updated = 3
    }
}