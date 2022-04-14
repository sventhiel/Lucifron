using LiteDB;

namespace Lucifron.ReST.Server.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public string Token { get; set; }
        public string Prefix { get; set; }
        public string Pattern { get; set; }

        [BsonRef("credentials")]
        public Credential Credential { get; set; }
    }
}