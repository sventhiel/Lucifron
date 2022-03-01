using Newtonsoft.Json;

namespace Lucifron.ReST.Models.DataCite
{
    public class DataCiteSubject
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}