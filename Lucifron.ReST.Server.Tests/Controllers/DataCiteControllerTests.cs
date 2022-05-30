using LiteDB;
using Lucifron.ReST.Library.Models;
using Lucifron.ReST.Server.Controllers;
using Lucifron.ReST.Server.Services;
using NUnit.Framework;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lucifron.ReST.Server.Tests.Controllers
{
    [TestFixture]
    public class DataCiteControllerTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        { }

        [Test]
        public void Create()
        {
            try
            {
                var connectionString = new ConnectionString("Filename=C:\\Projects\\github\\sventhiel\\Lucifron\\Lucifron.ReST.Server\\Database\\Lucifron.db;Connection=Shared");
                var userService = new UserService(connectionString);
                var user = userService.FindById(1);

                var model = new CreateDataCiteModel()
                {
                    Id = "jlkjsdf/jshjdf"
                };

                var controller = new DataCiteController()
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    Configuration = new HttpConfiguration(),
                    ActionContext = new HttpActionContext(),
                    ControllerContext = new HttpControllerContext(),
                };

                controller.Request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "sdfsdf");
                controller.ControllerContext.RouteData.Values.Add("user", user);

                var result = controller.Post(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}