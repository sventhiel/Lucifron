using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Library.Utils
{
    public class NestedJsonConverter<T> : JsonConverter
        where T : new()
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new T();
            var data = JObject.Load(reader);

            // Get all properties of a provided class
            var properties = result
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);

            foreach (var propertyInfo in properties)
            {
                var jsonPropertyAttribute = propertyInfo
                    .GetCustomAttributes(false)
                    .FirstOrDefault(attribute => attribute is JsonPropertyAttribute);

                // Use either custom JSON property or regular property name
                var propertyName = jsonPropertyAttribute != null
                    ? ((JsonPropertyAttribute)jsonPropertyAttribute).PropertyName
                    : propertyInfo.Name;

                if (string.IsNullOrEmpty(propertyName))
                {
                    continue;
                }

                // Split by the delimiter, and traverse recursively according to the path
                var names = propertyName.Split('/');
                object propertyValue = null;
                JToken token = null;
                for (int i = 0; i < names.Length; i++)
                {
                    var name = names[i];
                    var isLast = i == names.Length - 1;

                    token = token == null
                        ? data.GetValue(name, StringComparison.OrdinalIgnoreCase)
                        : ((JObject)token).GetValue(name, StringComparison.OrdinalIgnoreCase);

                    if (token == null)
                    {
                        // Silent fail: exit the loop if the specified path was not found
                        break;
                    }

                    if (token is JValue || token is JArray || (token is JObject && isLast))
                    {
                        // simple value / array of items / complex object (only if the last chain)
                        propertyValue = token.ToObject(propertyInfo.PropertyType, serializer);
                    }
                }

                if (propertyValue == null)
                {
                    continue;
                }

                propertyInfo.SetValue(result, propertyValue);
            }

            return result;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}
