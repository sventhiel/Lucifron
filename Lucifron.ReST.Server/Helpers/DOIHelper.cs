using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Lucifron.ReST.Server.Helpers
{
    public class DOIHelper
    {
        public static string Create(string prefix, string name, long id)
        {
            return $"{prefix}/{name}-{id}-{generate()}";
        }

        public static bool Validate(string doi, string prefix, string name)
        {
            string pattern = $@"{prefix}/{name}-\d+-[a-z0-9]+";
            // Create a Regex
            Regex rg = new Regex(pattern);
            return rg.IsMatch(doi);
        }

        private static string generate(int size = 6)
        {
            // Characters except I, l, O, 1, and 0 to decrease confusion when hand typing tokens
            var charSet = "abcdefghijkmnopqrstuvwxyz23456789";
            var chars = charSet.ToCharArray();
            var data = new byte[1];

            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
                var result = new StringBuilder(size);
                foreach (var b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                return result.ToString();
            }
        }
    }
}