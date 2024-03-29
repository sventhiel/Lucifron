﻿using LiteDB;
using Lucifron.ReST.Server.Services;
using System.Configuration;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lucifron.ReST.Server.Attributes
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ApiAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //
            // Preparation
            var token = actionContext.Request.Headers.Authorization?.ToString().Substring("Bearer ".Length).Trim();
            string ipv4 = HttpContext.Current.Request.UserHostAddress;

            //
            // User
            var userService = new UserService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));
            //var user = userService.FindByIPv4AndToken(ipv4, token);
            var user = userService.FindByToken(token);

            if (user != null)
            {
                // TODO
                actionContext.ControllerContext.RouteData.Values.Add("user", user);
                return;
            }

            //
            // Error
            actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            actionContext.Response.Content = new StringContent("Token is not valid.");
            return;
        }
    }
}