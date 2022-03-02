using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteCreator
    {
        [JsonProperty("name")]
        public string Name
        { get { return $"{this.FamilyName}, {this.GivenName}"; } }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("nameType")]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonRequired]
        public DataCiteCreatorType NameType { get; set; }

        public static DataCiteCreator Convert(string name, DataCiteCreatorType nameType)
        {
            switch (nameType)
            {
                case DataCiteCreatorType.Personal:
                    return new DataCiteCreator()
                    {
                        GivenName = name.Substring(0, name.IndexOf(" ")),
                        FamilyName = name.Substring(name.IndexOf(" ") + 1),
                        NameType = nameType
                    };
                default:
                    return null;
            }
            
        }
    }

    public enum DataCiteCreatorType
    {
        [EnumMember(Value = "Personal")]
        Personal
    }
}