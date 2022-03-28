using Fare;
using Lucifron.ReST.Library.Enumerations;
using Lucifron.ReST.Library.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        [TestCase("{DatasetId}[ab]{4,6}c")]
        public void Pattern(string pattern)
        {
            try
            {
                var placeholders = new Dictionary<Placeholder, string>();
                placeholders.Add(Placeholder.DatasetId, "1337");

                if (placeholders != null)
                {
                    foreach (var placeholder in placeholders)
                    {
                        pattern = pattern.Replace(placeholder.Key.GetPlaceholderValue(), placeholder.Value);
                    }
                }
                Xeger xeger = new Xeger(pattern, new Random());

                var x = xeger.Generate();

                Regex rg = new Regex(pattern);
                var y = rg.IsMatch(x);

                //Assert
                Assert.That(pattern, Is.EqualTo("hgdjf"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}