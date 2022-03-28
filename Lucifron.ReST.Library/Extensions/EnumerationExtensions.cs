using Lucifron.ReST.Library.Attributes;
using System;
using System.Reflection;

namespace Lucifron.ReST.Library.Extensions
{
    public static class EnumerationExtensions
    {
        public static string GetPlaceholderValue(this Enum value)
        {
            Type Type = value.GetType();

            FieldInfo fieldInfo = Type.GetField(value.ToString());

            var Attribute = fieldInfo.GetCustomAttribute(
                typeof(PlaceholderValueAttribute)
            ) as PlaceholderValueAttribute;

            return Attribute.Value;
        }
    }
}