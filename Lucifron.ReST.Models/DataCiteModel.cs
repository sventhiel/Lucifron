using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models
{
    public class DataCiteModel
    {
        [JsonProperty("data")]
        public DataCiteData Data { get; set; }
    }

    public class DataCiteData
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Type Type { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class DataCiteCreator
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DataCiteSubject
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }

    public class DataCiteDescription
    {
        [JsonProperty("lang")]
        public string Language { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("descriptionType")]
        public DataCiteDescriptionType DataCiteDescriptionType { get; set; }
    }

    public class DataCiteTitle
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class DataCiteTypes
    {
        [JsonProperty("resourceTypeGeneral")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceType ResourceTypeGeneral { get; set; }
    }

    public class DataCiteDate
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dateType")]
        public DataCiteDateType Type { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("doi")]
        public string DOI { get; set; }

        [JsonProperty("event")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Event Event { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("dates")]
        public List<DataCiteDate> Dates { get; set; }

        [JsonProperty("publicationYear")]
        public int PublicationYear { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("creators")]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("titles")]
        public List<DataCiteTitle> Titles { get; set; }

        [JsonProperty("types")]
        public DataCiteTypes Types { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }

    public enum Event
    {
        [EnumMember(Value = "publish")]
        Publish,

        [EnumMember(Value = "register")]
        Register,

        [EnumMember(Value = "hide")]
        Hide
    }

    public enum ResourceType
    {
        [EnumMember(Value = "Dataset")]
        Dataset
    }

    public enum DataCiteDescriptionType
    {
        [EnumMember(Value = "Abstract")]
        Abstract,
        [EnumMember(Value = "Methods")]
        Methods,
    }

    public enum Type
    {
        [EnumMember(Value = "dois")]
        DOIs
    }

    public enum DataCiteDateType
    {
        [EnumMember(Value = "Issued")]
        Issued
    }
}