using Lucifron.ReST.Models;
using Lucifron.ReST.Server.Attributes;
using Lucifron.ReST.Server.Entities;
using Lucifron.ReST.Server.Helpers;
using Lucifron.ReST.Server.Models;
using Lucifron.ReST.Server.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lucifron.ReST.Server.Controllers
{
    public class DOIsController : ApiController
    {
        private readonly DataCiteConnectionString _dataCiteConnectionString;

        public DOIsController()
        {
            _dataCiteConnectionString = new DataCiteConnectionString(ConfigurationManager.ConnectionStrings["DataCiteEndpoint"].ConnectionString);
        }

        [ApiAuth]
        public HttpResponseMessage Get(long id)
        {
            var user = ControllerContext.RouteData.Values["user"] as User;


            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new DOIModel() { DOI = DOIHelper.Create(user.Prefix, user.Name, id) });
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [ApiAuth]
        public HttpResponseMessage Get(string doi)
        {
            var client = new RestClient(_dataCiteConnectionString.Host);
            var request = new RestRequest($"dois/{doi}", Method.GET);

            var response = client.Execute(request);

            return Request.CreateResponse(response.StatusCode, response.Content);
        }

        [ApiAuth]
        public HttpResponseMessage Post([FromBody] DataCiteModel model)
        {
            var user = ControllerContext.RouteData.Values["user"] as User;

            if (!DOIHelper.Validate(model.Data.Attributes.DOI, user.Prefix, user.Name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Token.");
            }

            var client = new RestClient(_dataCiteConnectionString.Host);
            client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

            var request = new RestRequest($"dois", Method.POST).AddJsonBody(JsonConvert.SerializeObject(model, serializerSettings));

            var response = client.Execute(request);

            return Request.CreateResponse(response.StatusCode, response.Content);
        }

        [ApiAuth]
        public HttpResponseMessage Put(string doi, [FromBody] DataCiteModel model)
        {
            var client = new RestClient(_dataCiteConnectionString.Host);
            client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

            var request = new RestRequest($"dois/{doi}", Method.PUT).AddJsonBody(JsonConvert.SerializeObject(model, serializerSettings));

            var response = client.Execute(request);

            return Request.CreateResponse(response.StatusCode, response.Content);
        }

        [ApiAuth]
        public HttpResponseMessage Delete(string doi)
        {
            var client = new RestClient(_dataCiteConnectionString.Host);
            client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);
            var request = new RestRequest($"dois/{doi}", Method.DELETE);

            var response = client.Execute(request);

            return Request.CreateResponse(response.StatusCode, response.Content);
        }
    }
}