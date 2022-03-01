using Lucifron.ReST.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace Lucifron.ReST.Library.Services
{
    public interface IDataCiteService
    {
        string Create(DataCiteModel model);

        string Find();

        string FindByDOI(string doi);

        string Update(DataCiteModel model);

        string Delete(string doi);
    }

    public class DataCiteService : IDataCiteService
    {
        private string _Host;
        private string _Token;

        public DataCiteService(string host, string token)
        {
            _Host = host;
            _Token = token;
        }

        public string Create(DataCiteModel model)
        {
            var client = new RestClient(_Host);
            client.Authenticator = new JwtAuthenticator(_Token);

            var request = new RestRequest($"api/dois", Method.POST).AddJsonBody(model);
            var response = client.Execute(request);

            return response.Content;
        }

        public string Find()
        {
            throw new NotImplementedException();
        }

        public string FindByDOI(string doi)
        {
            var client = new RestClient(_Host);
            client.Authenticator = new JwtAuthenticator(_Token);

            var request = new RestRequest($"api/dois/{doi}", Method.GET);
            var response = client.Execute(request);

            return response.Content;
        }

        public string Update(DataCiteModel model)
        {
            var client = new RestClient(_Host);
            client.Authenticator = new JwtAuthenticator(_Token);

            var request = new RestRequest($"api/dois/{model.Data.Attributes.DOI}", Method.PUT).AddJsonBody(model);
            var response = client.Execute(request);

            return response.Content;
        }

        public string Delete(string doi)
        {
            var client = new RestClient(_Host);
            client.Authenticator = new JwtAuthenticator(_Token);

            var request = new RestRequest($"api/dois/{doi}", Method.DELETE);
            var response = client.Execute(request);

            return response.Content;
        }
    }
}