using Lucifron.ReST.Library.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class CreateDataCiteModel
    {
        #region data

        [JsonProperty("data.id")]
        public string Id { get; set; }

        [JsonProperty("data.type")]
        public DataCiteType Type { get; set; }

        #region data.attributes

        [JsonProperty("data.attributes.creators")]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("data.attributes.contributors")]
        public List<DataCiteCreator> Contributors { get; set; }

        [JsonProperty("data.attributes.descriptions")]
        public List<DataCiteDescription> Descriptions { get; set; }

        [JsonProperty("data.attributes.doi")]
        public string DOI { get; set; }

        [JsonProperty("data.attributes.prefix")]
        public string Prefix { get; set; }

        [JsonProperty("data.attributes.suffix")]
        public string Suffix { get; set; }

        [JsonProperty("data.attributes.event")]
        public DataCiteEventType Event { get; set; }

        [JsonProperty("data.attributes.publicationYear")]
        public int PublicationYear { get; set; }

        [JsonProperty("data.attributes.publisher")]
        public string Publisher { get; set; }

        [JsonProperty("data.attributes.subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("data.attributes.titles")]
        public List<DataCiteTitle> Titles { get; set; }

        #region data.attributes.types

        [JsonProperty("data.attributes.types.resourceTypeGeneral")]
        public DataCiteResourceType ResourceTypeGeneral { get; set; }

        [JsonProperty("data.attributes.types.resourceType")]
        public string ResourceType { get; set; }

        #endregion data.attributes.types

        [JsonProperty("data.attributes.url")]
        public string URL { get; set; }

        #endregion data.attributes

        #endregion

        public CreateDataCiteModel()
        {
            Creators = new List<DataCiteCreator>();
            Contributors = new List<DataCiteCreator>();
            Descriptions = new List<DataCiteDescription>();
            Subjects = new List<DataCiteSubject>();
            Titles = new List<DataCiteTitle>();
        }

        public static CreateDataCiteModel Deserialize(string json)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            return JsonConvert.DeserializeObject<CreateDataCiteModel>(json, jsonSettings);
        }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public class ReadDataCiteModel
    {
        #region data

        [JsonProperty("data.id")]
        public string Id { get; set; }

        [JsonProperty("data.type")]
        public DataCiteType Type { get; set; }

        #endregion

        public static ReadDataCiteModel Deserialize(string json)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            return JsonConvert.DeserializeObject<ReadDataCiteModel>(json, jsonSettings);
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

    public enum DataCiteResourceType
    {
        [EnumMember(Value = "Audiovisual")]
        Audiovisual = 1,

        [EnumMember(Value = "Book")]
        Book = 2,

        [EnumMember(Value = "BookChapter")]
        BookChapter = 3,

        [EnumMember(Value = "Collection")]
        Collection = 4,

        [EnumMember(Value = "ComputationalNotebook")]
        ComputationalNotebook = 5,

        [EnumMember(Value = "ConferencePaper")]
        ConferencePaper = 6,

        [EnumMember(Value = "ConferenceProceeding")]
        ConferenceProceeding = 7,

        [EnumMember(Value = "DataPaper")]
        DataPaper = 8,

        [EnumMember(Value = "Dataset")]
        Dataset = 9
    }

    public enum DataCiteType
    {
        [EnumMember(Value = "dois")]
        DOIs = 1
    }
}