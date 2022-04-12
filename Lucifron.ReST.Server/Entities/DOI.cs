using LiteDB;
using System;

namespace Lucifron.ReST.Server.Entities
{
    public class DOI
    {
        public string Prefix { get; set; }

        public string Suffix { get; set; }

        [BsonRef("users")]
        public User User { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset IssueDate { get; set; }
    }
}