﻿using Lucifron.ReST.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Extensions
{
    public static class DataCiteDataExtensions
    {
        public static DataCiteAttributes Attributes(this DataCiteData model)
        {
            if (model.Attributes == null)
                model.Attributes = new DataCiteAttributes();

            return model.Attributes;
        }

        public static DataCiteData SetType(this DataCiteData model, DataCiteType type)
        {
            model.Type = type;

            return model;
        }
    }
}
