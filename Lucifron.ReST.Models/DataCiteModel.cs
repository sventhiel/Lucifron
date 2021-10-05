﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lucifron.ReST.Models
{
    public class DataCiteModel
    {
        [JsonProperty("data")]
        public DataCiteData Data { get; set; }
    }

    public class DataCiteData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class DataCiteCreator
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DataCiteTitle
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class DataCiteTypes
    {
        [JsonProperty("resourceTypeGeneral")]
        public string ResourceTypeGeneral { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("doi")]
        public string DOI { get; set; }

        [JsonProperty("event")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Event Event { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("publicationYear")]
        public int PublicationYear { get; set; }

        [JsonProperty("creators")]
        public List<DataCiteCreator> Creators { get; set; }

        [JsonProperty("titles")]
        public List<DataCiteTitle> Titles { get; set; }

        [JsonProperty("types")]
        public DataCiteTypes Types { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }

    public enum Event
    {
        [EnumMember(Value = "publish")]
        Publish,

        [EnumMember(Value = "register")]
        Register,

        [EnumMember(Value = "hide")]
        Hide
    }
}