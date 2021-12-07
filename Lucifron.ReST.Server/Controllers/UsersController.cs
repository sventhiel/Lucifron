using LiteDB;
using Lucifron.ReST.Server.Models;
using Lucifron.ReST.Server.Services;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Lucifron.ReST.Server.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            //
            // Create an instance of the user service to get all users from the database.
            var userService = new UserService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

            //
            // Instead of returning all users from the database, each of them is
            // converted into a specific model, containing the properties
            // that should show up in the table of the view.
            var users = userService.Find().Select(u => ReadUserModel.Convert(u));

            return View(users);
        }

        /// <summary>
        /// [tba]
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            //
            // Simply return the view with an empty model.
            return View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            //
            // After submit of the "create user" form, first validate the model.
            // If the model is valid (which means, that all fields are filled properly),
            // create a new user to the database.
            if (ModelState.IsValid)
            {
                //
                // Create an instance of the user service to create a new user to the database.
                var userService = new UserService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

                //
                // Call the user service with necessary properties to create a new user.
                userService.Create(model.Name, model.Prefix, model.IPv4, model.Credential);

                //
                // After creation of the new user, redirect to the table of all users.
                return RedirectToAction("Index", "Users");
            }

            return View(model);
        }
    }
}