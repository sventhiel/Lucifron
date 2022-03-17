using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteModel
    {
        [JsonProperty("data")]
        [Required]
        public DataCiteData Data { get; set; }
    }
}