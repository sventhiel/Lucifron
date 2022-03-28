using System;

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