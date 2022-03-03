using Lucifron.ReST.Models.DataCite;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Models
{
    public class DataCiteModel
    {
        [JsonProperty("data")]
        [Required]
        public DataCiteData Data { get; set; }
    }
}