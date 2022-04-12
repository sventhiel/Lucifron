using LiteDB;
using Lucifron.ReST.Server.Models;
using Lucifron.ReST.Server.Services;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Lucifron.ReST.Server.Controllers
{
    public class PlaceholdersController : Controller
    {
        // GET: Placeholders
        public ActionResult Index()
        {
            var placeholderService = new PlaceholderService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

            //
            // Instead of returning all users from the database, each of them is
            // converted into a specific model, containing the properties
            // that should show up in the table of the view.
            var placeholders = placeholderService.Find().Select(u => ReadPlaceholderModel.Convert(u));

            return View(placeholders);
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
        public ActionResult Create(CreatePlaceholderModel model)
        {
            //
            // After submit of the "create user" form, first validate the model.
            // If the model is valid (which means, that all fields are filled properly),
            // create a new user to the database.
            if (ModelState.IsValid)
            {
                //
                // Create an instance of the user service to create a new user to the database.
                var placeholderService = new PlaceholderService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

                //
                // Call the user service with necessary properties to create a new user.
                placeholderService.Create(model.Expression, model.RegularExpression, model.UserId);

                //
                // After creation of the new user, redirect to the table of all users.
                return RedirectToAction("Index", "Placeholders");
            }

            return View(model);
        }
    }
}