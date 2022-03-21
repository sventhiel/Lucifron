﻿using Lucifron.ReST.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [TestCase("Maria Jose Alvarez Blanco", "Maria", "Alvarez Blanco")]
        public void Check_DataCiteCreatorNames(string name, string firstname, string lastname)
        {
            try
            {
                var creator = DataCiteCreator.Convert(name, DataCiteCreatorType.Personal);

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
