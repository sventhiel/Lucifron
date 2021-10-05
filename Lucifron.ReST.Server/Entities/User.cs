﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucifron.ReST.Server.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public string Token { get; set; }
        public string Prefix { get; set; }
    }
}