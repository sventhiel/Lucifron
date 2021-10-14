using LiteDB;
using Lucifron.ReST.Server.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Lucifron.ReST.Server.Services
{
    public class UserService
    {
        private readonly ConnectionString _connectionString;

        public UserService(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public long Create(string name, string prefix, string ipv4)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("users");

                var user = new User()
                {
                    Name = name,
                    IPv4 = ipv4,
                    Prefix = prefix,
                    Token = generate(64)
                };

                return col.Insert(user);
            }
        }

        public bool Delete(long id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("users");

                return col.Delete(id);
            }
        }

        public User FindByIPv4AndToken(string ipv4, string token)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("users");

                return col.FindOne(c => c.IPv4 == ipv4 && c.Token == token);
            }
        }

        public List<User> Get()
        {
            List<User> users = null;

            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("users");

                users = col.Query().ToList();
            }

            return users;
        }

        private static string generate(int size = 64)
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