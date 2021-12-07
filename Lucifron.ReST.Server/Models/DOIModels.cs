using Newtonsoft.Json;

namespace Lucifron.ReST.Server.Models
{
    public class DOIModel
    {
        [JsonProperty("doi")]
        public string DOI { get; set; }
    }
}