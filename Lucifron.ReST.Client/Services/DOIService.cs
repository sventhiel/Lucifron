using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lucifron.ReST.Client.Services
{
    public interface IDOIService
    {

    }

    public class DOIService
    {
        private string _Host;
        private string _Token;

        public DOIService(string host, string token)
        {
            _Host = host;
            _Token = token;
        }

        public string Create(Dictionary<string, string> placeholders = null)
        {
            try
            {
                var client = new RestClient(_Host);
                client.Authenticator = new JwtAuthenticator(_Token);

                var request = new RestRequest($"api/dois", Method.POST).AddJsonBody(placeholders);
                var response = client.Execute(request);

                if (!response.IsSuccessful)
                    return string.Empty;

                return response.Content;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
