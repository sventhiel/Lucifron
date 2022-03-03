using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteTypes
    {
        [JsonProperty("resourceTypeGeneral")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteResourceType ResourceTypeGeneral { get; set; }

        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }
    }

    public enum DataCiteResourceType
    {
        [EnumMember(Value = "Audiovisual")]
        Audiovisual,
        [EnumMember(Value = "Book")]
        Book,
        [EnumMember(Value = "BookChapter")]
        BookChapter,
        [EnumMember(Value = "Collection")]
        Collection,
        [EnumMember(Value = "ComputationalNotebook")]
        ComputationalNotebook,
        [EnumMember(Value = "ConferencePaper")]
        ConferencePaper,
        [EnumMember(Value = "ConferenceProceeding")]
        ConferenceProceeding,
        [EnumMember(Value = "DataPaper")]
        DataPaper,
        [EnumMember(Value = "Dataset")]
        Dataset
    }
}