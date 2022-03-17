using Newtonsoft.Json;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteSubject
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}