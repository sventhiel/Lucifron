using Lucifron.ReST.Models;
using RestSharp;
using System.Collections.Generic;

namespace Lucifron.ReST.Library.Services
{
    public interface IDataCiteService
    {

    }

    public class DataCiteService
    {
        public DataCiteService()
        {
        }

        public string Create()
        {
            var x = new DataCiteModel()
            {
                Data = new DataCiteData()
                {
                    Type = Type.DOIs,
                    Attributes = new Attributes()
                    {
                        Creators = new List<DataCiteCreator>() { new DataCiteCreator() { Name = "Hans Peter Wolle" } },
                        Titles = new List<DataCiteTitle>() { new DataCiteTitle() { Title = "Die unendliche Geschichte - Teil 2" } },
                        DOI = "10.23720/xhdy-0021",
                        Event = Event.Register,
                        Types = new DataCiteTypes() { ResourceTypeGeneral = ResourceType.Dataset },
                        PublicationYear = 2000,
                        Publisher = "Löwenzahn",
                        URL = "https://google.de"
                    }
                }
            };

            var client = new RestClient("https://localhost:44372");
            var request = new RestRequest($"api/dois", Method.POST).AddJsonBody(x);
            var y = client.Execute(request);

            return y.Content;
        }
    }
}