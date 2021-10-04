using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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