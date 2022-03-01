using Lucifron.ReST.Library.Services;
using Newtonsoft.Json.Linq;
using System;

namespace Lucifron.ReST.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataCiteService x = new DataCiteService("", "");
            var response = x.Create(new Models.DataCiteModel());

            JObject joResponse = JObject.Parse(response);
            string doi = joResponse["doi"].ToString();

            Console.WriteLine(response);

            Console.ReadLine();
        }
    }
}