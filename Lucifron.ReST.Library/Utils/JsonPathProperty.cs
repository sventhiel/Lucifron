using Newtonsoft.Json.Serialization;

namespace Lucifron.ReST.Library.Utils
{
    public class JsonPathProperty
    {
        /// <summary>
        /// The <see cref="JsonProperty"/> associated with the same property as the <see cref="JsonPathAttribute"/>.
        /// </summary>
        public JsonProperty JsonProperty { get; set; }

        /// <summary>
        /// The JSONPath expression to be evaluated for the property.
        /// </summary>
        public string Expression { get; set; }
    }
}
