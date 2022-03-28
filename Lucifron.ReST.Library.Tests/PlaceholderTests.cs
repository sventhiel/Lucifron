using Lucifron.ReST.Library.Enumerations;
using Lucifron.ReST.Library.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lucifron.ReST.Library.Tests
{
    [TestFixture]
    public class PlaceholderTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { }

        [TestCase("{DatasetId}[ab]{4,6}c")]
        public void Test(string pattern)
        {
            try
            {
                var dict = new Dictionary<Placeholder, string>();

                dict.Add(Placeholder.DatasetId, "12345");

                var doi = pattern.Replace(dict.First().Key.GetPlaceholderValue(), dict.First().Value);

                //Assert
                Assert.That(doi, Is.EqualTo("hgdjf"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}