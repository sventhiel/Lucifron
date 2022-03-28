using Lucifron.ReST.Server.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Server.Tests.Helpers
{
    [TestFixture]
    public class DOIHelperTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { }

        [TestCase("<DatasetId>[ab]{4,6}c")]
        public void Pattern(string pattern)
        {

        }
    }
}
