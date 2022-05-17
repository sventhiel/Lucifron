using Lucifron.ReST.Library.Extensions;
using Lucifron.ReST.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
                var model = new CreateDataCiteModel();

                model.Id = "mlkjl";
                model.Creators = new List<DataCiteCreator>();
                model.Creators.Add(new DataCiteCreator("Sven Thiel", DataCiteCreatorType.Personal));
                model.Creators.Add(new DataCiteCreator("David Schöne", DataCiteCreatorType.Personal));
                model.Creators.Add(new DataCiteCreator("Franziska Zander", DataCiteCreatorType.Personal));
                var s = model.Serialize();

                var test = CreateDataCiteModel.Deserialize(s);

                //Assert
                Assert.That(true, Is.False);
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