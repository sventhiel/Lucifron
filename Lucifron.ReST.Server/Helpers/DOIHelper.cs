using Fare;
using LiteDB;
using Lucifron.ReST.Server.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lucifron.ReST.Server.Helpers
{
    public class DOIHelper
    {
        public static string Create(string prefix, string pattern, Dictionary<string, string> placeholders)
        {
            try
            {
                // check placeholders and replace them
                if (placeholders != null)
                {
                    foreach (var placeholder in placeholders)
                    {
                        pattern = pattern.Replace(placeholder.Key, placeholder.Value);
                    }
                }

                // create a random suffix that matches the pattern and return it
                Xeger xeger = new Xeger($"{pattern}", new Random());
                return $"{prefix}/{xeger.Generate()}";
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool Validate(string doi, string prefix, string pattern, Dictionary<string, string> placeholders = null)
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
                Regex rg = new Regex($"{prefix}/{pattern}");
                return rg.IsMatch(doi);
            }
            catch
            {
                return false;
            }
        }
    }
}