using LiteDB;
using System;

namespace Lucifron.ReST.Server.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public string Token { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool IsActive { get; set; }

        [BsonRef("credentials")]
        public Credential Credential { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}