using Fare;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lucifron.ReST.Server.Helpers
{
    public class SuffixHelper
    {
        /// <summary>
        /// tbd
        /// </summary>
        /// <param name="pattern">the initial pattern of the suffix</param>
        /// <param name="placeholders">key values get replaced by their value within the pattern</param>
        /// <returns>the suffix as a string or null.</returns>
        public static string Create(string pattern, Dictionary<string, string> placeholders)
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
                return xeger.Generate();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// tbd
        /// </summary>
        /// <param name="suffix"></param>
        /// <param name="pattern"></param>
        /// <param name="placeholders"></param>
        /// <returns></returns>
        public static bool Validate(string suffix, string pattern, Dictionary<string, string> placeholders = null)
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
                return rg.IsMatch(suffix);
            }
            catch
            {
                return false;
            }
        }
    }
}