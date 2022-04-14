using Newtonsoft.Json;
using System;

namespace Lucifron.ReST.Server.Models
{
    public class CreateDOIModel
    {
        [JsonProperty("doi")]
        public string DOI { get => $"{this.Prefix}/{this.Suffix}"; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }

    public class ReadDOIModel
    {
        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public long UserId { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset IssueDate { get; set; }
    }
}