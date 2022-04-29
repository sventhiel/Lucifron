using LiteDB;
using Lucifron.ReST.Library.Extensions;
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lucifron.ReST.Server.Controllers
{
    public class DataCiteController : ApiController
    {
        public DataCiteController()
        {
        }

        [ApiAuth]
        public HttpResponseMessage Get(string doi)
        {
            try
            {

                var user = ControllerContext.RouteData.Values["user"] as User;
                var dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                var client = new RestClient(dataCiteConnectionString.Host);
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
        public HttpResponseMessage Post([FromBody] CreateDataCiteModel model)
        {
            try
            {
                // Preequisites
                var user = ControllerContext.RouteData.Values["user"] as User;
                var dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);
                var placeholderService = new PlaceholderService(new ConnectionString(ConfigurationManager.ConnectionStrings["Lucifron"].ConnectionString));

                // 
                if (!SuffixHelper.Validate(model.Suffix, user.Pattern, placeholderService.FindByUserId(user.Id)))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "The DOI suffix does not fit to the pattern of the user.");
                }

                // 
                List<ValidationResult> errors = new List<ValidationResult>();
                if(!model.Validate(out errors))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }

                var client = new RestClient(dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(dataCiteConnectionString.User, dataCiteConnectionString.Password);

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

                var request = new RestRequest($"dois", Method.POST).AddJsonBody(JsonConvert.SerializeObject(model));

                var response = client.Execute(request);

                return Request.CreateResponse(response.StatusCode, JsonConvert.DeserializeObject<ReadDataCiteModel>(response.Content));
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.StackTrace);
            }
        }

        [ApiAuth]
        public HttpResponseMessage Put(string doi, [FromBody] CreateDataCiteModel model)
        {
            try
            {
                var user = ControllerContext.RouteData.Values["user"] as User;
                var dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                var client = new RestClient(dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(dataCiteConnectionString.User, dataCiteConnectionString.Password);

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
                var dataCiteConnectionString = new DataCiteConnectionString(user.Credential.Host, user.Credential.User, user.Credential.Password);

                var client = new RestClient(dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(dataCiteConnectionString.User, dataCiteConnectionString.Password);
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