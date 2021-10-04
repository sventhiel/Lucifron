using Lucifron.ReST.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataCiteService x = new DataCiteService();
            var y = x.Create();

            Console.WriteLine(y);

            Console.ReadLine();
        }
    }
}
