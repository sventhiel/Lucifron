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
                var errors = new List<ValidationResult>();

                bool valid = model.Validate(out errors);

                //Assert
                Assert.That(valid, Is.False);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void AddAuthor_EmptyModel_Exception()
        {
            try
            {
                var model = new DataCiteModel();
                //model.AddAuthor("Sven Thiel", DataCiteCreatorType.Personal);
                //model.AddAuthor("Marcus Reinicke", DataCiteCreatorType.Personal);

                //Assert
                Assert.That(model.Data.Attributes.Creators, !Is.Null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void Serialize_EmptyModel_X()
        {
            try
            {
                var model = new DataCiteModel();

                model.Data.Type = DataCiteType.DOIs;

                //model.AddAuthor("Marcus Reinicke", DataCiteCreatorType.Personal);

                var errors = new List<ValidationResult>();

                bool valid = model.Validate(out errors);

                var json = model.Serialize();

                var model2 = DataCiteModel.Deserialize(json);

                //Assert
                Assert.That(model.Data.Attributes.Creators, !Is.Null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void Test()
        {
            var x = DeleteQueryWithGrammar.DeleteRowsFrom("hk");
        }
    }
}