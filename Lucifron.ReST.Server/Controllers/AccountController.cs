﻿using Lucifron.ReST.Server.Models;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace Lucifron.ReST.Server.Controllers
{
    public class AccountController : Controller
    {
        //
        //
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// tba
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
            return View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                if (ConfigurationManager.AppSettings["Admin_Token"] == model.Token)
                {
                    FormsAuthentication.SetAuthCookie(ConfigurationManager.AppSettings["Admin_Name"], false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The token is invalid!");
                }
            }
            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}