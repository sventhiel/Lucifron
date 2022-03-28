using Fare;
using Lucifron.ReST.Library.Enumerations;
using Lucifron.ReST.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lucifron.ReST.Server.Helpers
{
    public class DOIHelper
    {
        //public static string Create(string prefix, string name, long id)
        //{
        //    return $"{prefix}/{name}.{id}-{generate()}";
        //}

        public static string Create(string pattern, Dictionary<Placeholder, string> placeholders = null)
        {
            try
            {
                if (placeholders != null)
                {
                    foreach (var placeholder in placeholders)
                    {
                        pattern = pattern.Replace(placeholder.Key.GetPlaceholderValue(), placeholder.Value);
                    }
                }
                Xeger xeger = new Xeger(pattern, new Random());
                return xeger.Generate();
            }
            catch
            {
                return null;
            }
        }

        public static bool Validate(string doi, string pattern, Dictionary<Placeholder, string> placeholders)
        {
            try
            {
                if (placeholders != null)
                {
                    foreach (var placeholder in placeholders)
                    {
                        pattern = pattern.Replace(placeholder.Key.GetPlaceholderValue(), placeholder.Value);
                    }
                }
                Regex rg = new Regex(pattern);
                return rg.IsMatch(doi);
            }
            catch
            {
                return false;
            }
        }
    }
}