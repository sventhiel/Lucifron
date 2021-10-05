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
            //userService.Create("test", "::1", "jexis");

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}