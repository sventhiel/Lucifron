using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucifron.ReST.Server.Models
{
    public class ErrorModel
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("uid")]
        public string UId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class ErrorsModel
    {
        [JsonProperty("errors")]
        public List<ErrorModel> Errors { get; set; }
    }
}