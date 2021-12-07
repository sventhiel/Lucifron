using LiteDB;
using Lucifron.ReST.Server.Entities;
using System.Collections.Generic;

namespace Lucifron.ReST.Server.Services
{
    public class CredentialService
    {
        private readonly ConnectionString _connectionString;

        public CredentialService(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public long Create(string host, string user, string password)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Credential>("credentials");

                var credential = new Credential()
                {
                    Host = host,
                    User = user,
                    Password = password
                };

                return col.Insert(credential);
            }
        }

        public List<Credential> Find()
        {
            List<Credential> credentials = null;

            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Credential>("credentials");

                credentials = col.Query().ToList();
            }

            return credentials;
        }
    }
}