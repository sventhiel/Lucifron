using Lucifron.ReST.Library.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class DataCiteModel
    {
        #region data

        [JsonProperty("data.id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty("data.type")]
        public DataCiteType Type { get; set; }

        #region data.attributes

        [JsonRequired]
        [JsonProperty("data.attributes.doi")]
        public string Doi { get; set; }

        [JsonProperty("data.attributes.prefix")]
        public string Prefix { get; set; }

        [JsonProperty("data.attributes.suffix")]
        public string Suffix { get; set; }

        [JsonRequired]
        [JsonProperty("data.attributes.event")]
        public DataCiteEventType Event { get; set; }

        [JsonProperty("data.attributes.identifiers")]
        public List<DataCiteIdentifier> Identifiers { get; set; }

        [JsonRequired]
        [JsonProperty("data.attributes.creators")]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonRequired]
        [JsonProperty("data.attributes.titles")]
        public List<DataCiteTitle> Titles { get; set; }

        [JsonRequired]
        [JsonProperty("data.attributes.publisher")]
        public string Publisher { get; set; }

        [JsonRequired]
        [JsonProperty("data.attributes.publicationYear")]
        public int PublicationYear { get; set; }

        [JsonProperty("data.attributes.subjects")]
        public List<DataCiteSubject> Subjects { get; set; }

        [JsonProperty("data.attributes.contributors")]
        public List<DataCiteCreator> Contributors { get; set; }

        [JsonProperty("data.attributes.dates")]
        public List<DataCiteDate> Dates { get; set; }

        [JsonProperty("data.attributes.language")]
        public string Language { get; set; }

        #region data.attributes.types

        [JsonRequired]
        [JsonProperty("data.attributes.types.resourceTypeGeneral")]
        public DataCiteResourceType ResourceTypeGeneral { get; set; }

        [JsonRequired]
        [JsonProperty("data.attributes.types.resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("data.attributes.types.schemaOrg")]
        public string SchemaOrg { get; set; }

        [JsonProperty("data.attributes.types.bibtex")]
        public string Bibtex { get; set; }

        [JsonProperty("data.attributes.types.citeproc")]
        public string Citeproc { get; set; }

        [JsonProperty("data.attributes.types.ris")]
        public string Ris { get; set; }

        #endregion data.attributes.types

        // Related Identifiers

        [JsonProperty("data.attributes.version")]
        public string Version { get; set; }

        [JsonProperty("data.attributes.url")]
        public string URL { get; set; }

        [JsonProperty("data.attributes.descriptions")]
        public List<DataCiteDescription> Descriptions { get; set; }

        #endregion data.attributes

        #endregion

        public DataCiteModel()
        {
            Creators = new List<DataCiteCreator>();
            Contributors = new List<DataCiteCreator>();
            Dates = new List<DataCiteDate>();
            Descriptions = new List<DataCiteDescription>();
            Identifiers = new List<DataCiteIdentifier>();
            Subjects = new List<DataCiteSubject>();
            Titles = new List<DataCiteTitle>();
        }

        public static DataCiteModel Deserialize(string json)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };

            return JsonConvert.DeserializeObject<DataCiteModel>(json, jsonSettings);
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