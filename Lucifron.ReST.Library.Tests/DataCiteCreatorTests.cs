using Lucifron.ReST.Library.Models;
using NUnit.Framework;
using System;

namespace Lucifron.ReST.Library.Tests
{
    [TestFixture]
    public class DataCiteCreatorTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { }

        [TestCase("Jan van der Horst", "Jan", "van der Horst")]
        [TestCase("Maria Jose Alvarez Blanco", "Maria Jose Alvarez", "Blanco")]
        public void Check_DataCiteCreatorNames(string name, string firstname, string lastname)
        {
            try
            {
                var creator = new DataCiteCreator(name, DataCiteCreatorType.Personal);

                Assert.That(creator.GivenName, Is.EqualTo(firstname));
                Assert.That(creator.FamilyName, Is.EqualTo(lastname));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}