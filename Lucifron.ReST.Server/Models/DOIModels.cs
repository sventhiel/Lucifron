using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucifron.ReST.Server.Models
{
    public class DOIModel
    {
        [JsonProperty("doi")]
        public string DOI { get; set; }
    }
}