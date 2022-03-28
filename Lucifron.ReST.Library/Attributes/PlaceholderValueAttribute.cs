using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Attributes
{
    public class PlaceholderValueAttribute : Attribute
    {
        public string Value { get; protected set; }

        public PlaceholderValueAttribute(string value)
        {
            this.Value = value;
        }
    }
}
