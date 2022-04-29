using Lucifron.ReST.Library.Models;
using Lucifron.ReST.Server.Entities;
using Lucifron.ReST.Server.Utils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Lucifron.ReST.Server.Services
{
    public class DataCiteService
    {
        private DataCiteConnectionString _dataCiteConnectionString;
        private User _user;

        public DataCiteService(DataCiteConnectionString dataCiteConnectionString, User user)
        {
            _dataCiteConnectionString = dataCiteConnectionString;
            _user = user;
        }

        public ReadDataCiteModel Create(CreateDataCiteModel model)
        {
            try
            {
                var client = new RestClient(_dataCiteConnectionString.Host);
                client.Authenticator = new HttpBasicAuthenticator(_dataCiteConnectionString.User, _dataCiteConnectionString.Password);

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;

                var request = new RestRequest($"dois", Method.POST).AddJsonBody(JsonConvert.SerializeObject(model));

                var response = client.Execute(request);

                if (!response.IsSuccessful)
                    return null;

                return JsonConvert.DeserializeObject<ReadDataCiteModel>(response.Content);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReadDataCiteModel FindByDOI(string doi)
        {
            return null;
        }

        public List<ReadDataCiteModel> FindByPrefix(string prefix)
        {
            return null;
        }

        public List<ReadDataCiteModel> FindBySuffix(string suffix)
        {
            return null;
        }

        public List<ReadDataCiteModel> FindByUserId(long userId)
        {
            return null;
        }

        public ReadDataCiteModel Update(string doi, CreateDataCiteModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string doi)
        {
            return false;
        }

    }
}