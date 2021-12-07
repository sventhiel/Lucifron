using LiteDB;
using Lucifron.ReST.Server.Models;
using Lucifron.ReST.Server.Services;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Lucifron.ReST.Server.Controllers
{
    [Authorize]
    public class CredentialsController : Controller
    {
        // GET: Credentials
        public ActionResult Index()
        {
            var credentialService = new CredentialService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

            //
            // Instead of returning all users from the database, each of them is
            // converted into a specific model, containing the properties
            // that should show up in the table of the view.
            var credentials = credentialService.Find().Select(u => ReadCredentialModel.Convert(u));

            return View(credentials);
        }

        public ActionResult Create()
        {
            //
            // Simply return the view with an empty model.
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCredentialModel model)
        {
            //
            // After submit of the "create user" form, first validate the model.
            // If the model is valid (which means, that all fields are filled properly),
            // create a new user to the database.
            if (ModelState.IsValid)
            {
                //
                // Create an instance of the user service to create a new user to the database.
                var credentialService = new CredentialService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

                //
                // Call the user service with necessary properties to create a new user.
                credentialService.Create(model.Host, model.User, model.Password);

                //
                // After creation of the new user, redirect to the table of all users.
                return RedirectToAction("Index", "Credentials");
            }

            return View(model);
        }
    }
}