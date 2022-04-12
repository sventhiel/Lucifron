using Newtonsoft.Json;
using System;

namespace Lucifron.ReST.Server.Models
{
    public class DOIModel
    {
        [JsonProperty("doi")]
        public string DOI { get; set; }
    }

    public class ReadDOIModel
    {
        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public long UserId { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset IssueDate { get; set; }
    }

    public class CreateDOIModel
    {
        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public long UserId { get; set; }
    }
}