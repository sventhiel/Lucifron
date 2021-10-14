using LiteDB;
using Lucifron.ReST.Server.Models;
using Lucifron.ReST.Server.Services;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Lucifron.ReST.Server.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var userService = new UserService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

            var users = userService.Get().Select(u => ReadUserModel.Convert(u));

            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var userService = new UserService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));
                userService.Create(model.Name, model.Prefix, model.IPv4);
                return RedirectToAction("Index", "Users");
            }

            return View(model);
        }
    }
}