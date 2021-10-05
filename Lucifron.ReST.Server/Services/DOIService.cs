using LiteDB;

namespace Lucifron.ReST.Server.Services
{
    public class DOIService
    {
        private readonly ConnectionString _connectionString;

        public DOIService(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
    }
}