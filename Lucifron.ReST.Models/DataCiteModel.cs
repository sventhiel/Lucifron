using Lucifron.ReST.Models.DataCite;
using Newtonsoft.Json;

namespace Lucifron.ReST.Models
{
    public class DataCiteModel
    {
        [JsonProperty("data")]
        public DataCiteData Data { get; set; }
    }
}