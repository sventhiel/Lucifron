﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Types
{
    public enum DataCiteType
    {
        [EnumMember(Value = "dois")]
        DOIs = 1
    }
}
