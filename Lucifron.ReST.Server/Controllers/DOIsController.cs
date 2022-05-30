using LiteDB;
using Lucifron.ReST.Library.Models;
using Lucifron.ReST.Server.Attributes;
using Lucifron.ReST.Server.Entities;
using Lucifron.ReST.Server.Helpers;
using Lucifron.ReST.Server.Services;
using Lucifron.ReST.Server.Utils;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lucifron.ReST.Server.Controllers
{
    public class DOIsController : ApiController
    {
        private DataCiteConnectionString _dataCiteConnectionString;

        public DOIsController()
        {
        }

        [ApiAuth]
        public HttpResponseMessage Post([FromBody] Dictionary<string, string> placeholders)
        {
            try
            {
                var user = ControllerContext.RouteData.Values["user"] as User;
                var placeholderService = new PlaceholderService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));
                //var doiService = new DOIService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.Forbidden);

                var suffix = SuffixHelper.Create(user.Pattern, placeholders);

                if (suffix == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Da ging irgendetwas schief!");

                if (!SuffixHelper.Validate(suffix, user.Pattern, placeholderService.FindByUserId(user.Id)))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Verifikation ging schief!");

                var model = new CreateDOIModel()
                {
                    Prefix = user.Prefix,
                    Suffix = suffix
                };

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}