using Lucifron.ReST.Library.Services;
using System;

namespace Lucifron.ReST.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataCiteService x = new DataCiteService();
            var y = x.Create();

            Console.WriteLine(y);

            Console.ReadLine();
        }
    }
}