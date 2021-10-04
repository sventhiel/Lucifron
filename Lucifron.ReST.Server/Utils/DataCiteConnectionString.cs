using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

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