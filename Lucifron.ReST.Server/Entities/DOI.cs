using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucifron.ReST.Server.Entities
{
    public class DOI
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Created,

    }
}