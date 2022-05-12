using Lucifron.ReST.Server.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lucifron.ReST.Server.Controllers
{
    public class NamesController : ApiController
    {
        [ApiAuth]
        public HttpResponseMessage Get(string name)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
