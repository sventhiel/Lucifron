using Lucifron.ReST.Library.Extensions;
using Lucifron.ReST.Library.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lucifron.ReST.Client.Services
{
    public interface IDataCiteService
    {
        // create doi based on the given model
        string Create(DataCiteModel model);

        // find all related dois
        string Find();

        // find a specific doi
        string FindByDOI(string doi);

        // update an existing doi based on the given model
        string Update(DataCiteModel model);

        // delete a whole doi entry based on the given doi
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
            List<ValidationResult> results = null;

            if (!model.Validate(out results))
            {
                return null;
            }

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