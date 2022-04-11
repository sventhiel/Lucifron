using Fare;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lucifron.ReST.Server.Helpers
{
    public class DOIHelper
    {
        public static string Create(string pattern, Dictionary<string, string> placeholders = null)
        {
            try
            {
                if (placeholders != null)
                {
                    foreach (var placeholder in placeholders)
                    {
                        pattern = pattern.Replace(placeholder.Key, placeholder.Value);
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

        public static bool Validate(string doi, string pattern, Dictionary<string, string> placeholders = null)
        {
            try
            {
                if (placeholders != null)
                {
                    foreach (var placeholder in placeholders)
                    {
                        pattern = pattern.Replace(placeholder.Key, placeholder.Value);
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