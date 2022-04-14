﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Models
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
}
