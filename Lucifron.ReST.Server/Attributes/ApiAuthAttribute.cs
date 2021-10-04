using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lucifron.ReST.Server.Attributes
{
    public class ApiAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //
            // Preparation
            //var token = actionContext.Request.Headers.Authorization?.ToString().Substring("Bearer ".Length).Trim();
            //string ipv4 = HttpContext.Current.Request.UserHostAddress;

            //var clientService = new ClientService(new ConnectionString(""));
            //var user = clientService.FindByIPv4AndToken(ipv4, token);

            //if (user == null)
            //{
            //    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            //    actionContext.Response.Content = new StringContent("Token is not valid.");
            //    return;
            //}
        }
    }
}