using LiteDB;
using Lucifron.ReST.Server.Services;
using System.Configuration;
using System.Web.Mvc;

namespace Lucifron.ReST.Server.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            var userService = new UserService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

            var users = userService.Get();
            //userService.Create("idiv", "::1", "10.23720");
            //userService.Create("mydiv", "::1", "10.23720");
            //userService.Create("jexis", "::1", "10.23720");

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}