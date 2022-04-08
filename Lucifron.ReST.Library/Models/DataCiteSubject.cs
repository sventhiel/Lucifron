using Newtonsoft.Json;

namespace Lucifron.ReST.Library.Models
{
    public class DataCiteSubject
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonConstructor]
        protected DataCiteSubject()
        { }

        public DataCiteSubject(string subject)
        {
            Subject = subject;
        }
    }
}