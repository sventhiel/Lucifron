using Lucifron.ReST.Library.Extensions;
using Lucifron.ReST.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Library.Tests
{
    [TestFixture]
    public class DataCiteModelTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { }

        [Test]
        public void Validate_EmptyModel_False()
        {
            try
            {
                var model = new DataCiteModel();
                ICollection<ValidationResult> errors = new List<ValidationResult>();

                bool valid = model.Validate(out errors);

                //Assert
                Assert.That(valid, Is.False);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}