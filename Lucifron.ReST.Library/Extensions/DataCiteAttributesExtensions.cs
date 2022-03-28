using Lucifron.ReST.Library.Models;
using System.Collections.Generic;

namespace Lucifron.ReST.Library.Extensions
{
    public static class DataCiteAttributesExtensions
    {
        public static DataCiteAttributes AddCreator(this DataCiteAttributes model, DataCiteCreator creator)
        {
            if (model.Creators == null)
                model.Creators = new List<DataCiteCreator>();

            model.Creators.Add(creator);
            return model;
        }

        public static DataCiteAttributes AddCreators(this DataCiteAttributes model, List<DataCiteCreator> creators)
        {
            if (model.Creators == null)
                model.Creators = new List<DataCiteCreator>();

            model.Creators.AddRange(creators);
            return model;
        }

        public static DataCiteAttributes SetCreators(this DataCiteAttributes model, List<DataCiteCreator> creators)
        {
            model.Creators = new List<DataCiteCreator>(creators);
            return model;
        }

        public static DataCiteAttributes SetURL(this DataCiteAttributes model, string url)
        {
            model.URL = url;
            return model;
        }

        public static DataCiteAttributes SetEvent(this DataCiteAttributes model, DataCiteEventType type)
        {
            model.Event = type;
            return model;
        }
    }
}