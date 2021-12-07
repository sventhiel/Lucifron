namespace Lucifron.ReST.Server.Entities
{
    public class Credential
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }
}