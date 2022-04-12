using Lucifron.ReST.Library.Models;
using System;
using System.Collections.Generic;

namespace Lucifron.ReST.Client.Services
{
    public interface IDataCiteModelService
    {
        DataCiteModel AddAuthor(string name, DataCiteCreatorType type);

        DataCiteModel AddAuthor(Tuple<string, DataCiteCreatorType> author);

        DataCiteModel AddAuthors(List<Tuple<string, DataCiteCreatorType>> authors);

        DataCiteModel RemoveAuthor();

        DataCiteModel RemoveAuthors();

        DataCiteModel SetAuthors(List<Tuple<string, DataCiteCreatorType>> authors);

        List<DataCiteCreator> GetAuthors();

        DataCiteModel SetEvent(DataCiteEventType type);

        DataCiteModel GetEvent();
    }

    public class DataCiteModelService
    {
    }
}