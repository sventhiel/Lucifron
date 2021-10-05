using System.Data.Common;

namespace Lucifron.ReST.Server.Utils
{
    public class DataCiteConnectionString
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public DataCiteConnectionString(string connectionString)
        {
            DbConnectionStringBuilder dbConnectionStringBuilder = new DbConnectionStringBuilder();
            dbConnectionStringBuilder.ConnectionString = connectionString;

            Host = (string)dbConnectionStringBuilder["Host"];
            User = (string)dbConnectionStringBuilder["User"];
            Password = (string)dbConnectionStringBuilder["Password"];
        }
    }
}