using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Lucifron.ReST.Server.Helpers
{
    public class DOIHelper
    {
        public static string Create(string prefix, string name, long id)
        {
            return $"{prefix}/{name}-{id}-{generate()}";
        }

        public static bool Validate(string doi, string prefix, string name, long id)
        {
            //
            // Prefix
            string doi_prefix = doi.Split('/')[0];
            if (doi_prefix != prefix)
                return false;

            //
            // Suffix
            string doi_suffix = doi.Split('/')[1];
            
            string doi_name = doi_suffix.Split('-')[0];
            if (doi_name != name)
                return false;

            string doi_id = doi_suffix.Split('-')[1];
            if (doi_id != id.ToString())
                return false;

            string doi_alpha = doi_suffix.Split('-')[2];
            if (doi_alpha == null || doi_alpha.Length == 0)
                return false;

            return true;
        }

        private static string generate(int size = 6)
        {
            // Characters except I, l, O, 1, and 0 to decrease confusion when hand typing tokens
            var charSet = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
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