using NameParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteCreator
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("nameType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DataCiteCreatorType? NameType { get; set; }

        public static DataCiteCreator Convert(string name, DataCiteCreatorType? nameType = null)
        {
            switch (nameType)
            {
                case DataCiteCreatorType.Personal:
                    var person = new HumanName(name);

                    return new DataCiteCreator()
                    {
                        //GivenName = name.Substring(0, name.IndexOf(" ")),
                        GivenName = person.First,
                        //FamilyName = name.Substring(name.IndexOf(" ") + 1),
                        FamilyName = person.Last,
                        NameType = nameType
                    };

                case DataCiteCreatorType.Organizational:
                    return new DataCiteCreator()
                    {
                        Name = name,
                        NameType = nameType
                    };

                default:
                    return new DataCiteCreator()
                    {
                        Name = name
                    };
            }
        }

        public static DataCiteCreator Convert(string firstname, string lastname)
        {
            return new DataCiteCreator()
            {
                GivenName = firstname,
                FamilyName = lastname,
                NameType = DataCiteCreatorType.Personal
            };
        }
    }

    public enum DataCiteCreatorType
    {
        [EnumMember(Value = "Personal")]
        Personal,

        [EnumMember(Value = "Organizational")]
        Organizational
    }
}