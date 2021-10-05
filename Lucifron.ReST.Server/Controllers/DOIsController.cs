using Lucifron.ReST.Models;
using Lucifron.ReST.Server.Attributes;
using Lucifron.ReST.Server.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
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
            var doi = model.Data.Attributes.DOI.Split('/');

            // DOI check
            //var token = ActionContext.Request.Headers.Authorization?.ToString().Substring("Bearer ".Length).Trim();
            //string ipv4 = HttpContext.Current.Request.UserHostAddress;
            // if DOI not complete, add suffix

            //model.Data.Attributes.DOI += "abcdefg";

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