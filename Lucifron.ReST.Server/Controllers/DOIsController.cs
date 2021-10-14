using Lucifron.ReST.Models;
using Lucifron.ReST.Server.Attributes;
using Lucifron.ReST.Server.Entities;
using Lucifron.ReST.Server.Helpers;
using Lucifron.ReST.Server.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using System.Net.Http;
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
        public string Get(long id)
        {
            var user = ControllerContext.RouteData.Values["user"] as User;

            if (user != null)
            {
                return DOIHelper.Create(user.Prefix, user.Name, id);
            }

            return null;
        }

        [ApiAuth]
        public string Get(string doi)
        {
            var client = new RestClient(_dataCiteConnectionString.Host);
            var request = new RestRequest($"dois/{doi}", Method.GET);

            var x = client.Execute(request);

            return x.Content;
        }

        [ApiAuth]
        public string Post([FromBody] DataCiteModel model)
        {
            var user = ControllerContext.RouteData.Values["user"] as User;

            if(!DOIHelper.Validate(model.Data.Attributes.DOI, user.Prefix, user.Name))
            {
                ActionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                ActionContext.Response.Content = new StringContent("Token is not valid.");
                return ActionContext.Response.Content.ToString();
            }

            var client = new RestClient(_dataCiteConnectionString.Host);
            client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

            var request = new RestRequest($"dois", Method.POST).AddJsonBody(JsonConvert.SerializeObject(model, serializerSettings));

            var x = client.Execute(request);

            return x.Content;
        }

        [ApiAuth]
        public string Put(string doi, [FromBody] DataCiteModel model)
        {
            var client = new RestClient(_dataCiteConnectionString.Host);
            client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

            var request = new RestRequest($"dois/{doi}", Method.PUT).AddJsonBody(JsonConvert.SerializeObject(model, serializerSettings));

            var x = client.Execute(request);

            return x.Content;
        }

        [ApiAuth]
        public string Delete(string doi)
        {
            var client = new RestClient(_dataCiteConnectionString.Host);
            client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);
            var request = new RestRequest($"dois/{doi}", Method.DELETE);

            var x = client.Execute(request);

            return x.Content;
        }
    }
}