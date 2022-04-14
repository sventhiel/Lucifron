using LiteDB;
using Lucifron.ReST.Library.Models;
using Lucifron.ReST.Server.Attributes;
using Lucifron.ReST.Server.Entities;
using Lucifron.ReST.Server.Helpers;
using Lucifron.ReST.Server.Models;
using Lucifron.ReST.Server.Services;
using Lucifron.ReST.Server.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lucifron.ReST.Server.Controllers
{
    public class DataCiteController : ApiController
    {
        private DataCiteConnectionString _dataCiteConnectionString;

        public DataCiteController()
        {
        }

        /// <summary>
        /// Get a specific DOI from DataCite.
        /// </summary>
        /// <param name="doi"></param>
        /// <returns></returns>
        [ApiAuth]
        public HttpResponseMessage Get(string doi)
        {
            try
            {
                var user = ControllerContext.RouteData.Values["user"] as User;
                _dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                var client = new RestClient(_dataCiteConnectionString.Host);
                var request = new RestRequest($"dois/{doi}", Method.GET);

                var response = client.Execute(request);

                return Request.CreateResponse(response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [ApiAuth]
        public HttpResponseMessage Post([FromBody] DataCiteModel model)
        {
            try
            {
                var user = ControllerContext.RouteData.Values["user"] as User;
                _dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                if (!SuffixHelper.Validate(model.DOI, user.Prefix, null))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Token.");
                }

                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid model.");
                }

                var client = new RestClient(_dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

                var request = new RestRequest($"dois", Method.POST).AddJsonBody(JsonConvert.SerializeObject(model));

                var response = client.Execute(request);

                return Request.CreateResponse(response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [ApiAuth]
        public HttpResponseMessage Put(string doi, [FromBody] DataCiteModel model)
        {
            try
            {
                var user = ControllerContext.RouteData.Values["user"] as User;
                _dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                var client = new RestClient(_dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

                var request = new RestRequest($"dois/{doi}", Method.PUT).AddJsonBody(JsonConvert.SerializeObject(model, serializerSettings));

                var response = client.Execute(request);

                return Request.CreateResponse(response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [ApiAuth]
        public HttpResponseMessage Delete(string doi)
        {
            try
            {
                var user = ControllerContext.RouteData.Values["user"] as User;
                _dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                var client = new RestClient(_dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);
                var request = new RestRequest($"dois/{doi}", Method.DELETE);

                var response = client.Execute(request);

                return Request.CreateResponse(response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}