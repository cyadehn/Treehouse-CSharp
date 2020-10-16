using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoccerStats
{
    public class NewsSearch
    {
        public string Type { get; set; }
        public string ReadLink { get; set; }
        public QueryContext QueryContext { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public List<Sort> Sort { get; set; }
        [JsonProperty(PropertyName="value")]
        public List<NewsResult> NewsResults { get; set; }
    }

    public class QueryContext
    {
        public string originalQuery { get; set; }
        public bool adultIntent { get; set; }
    }

    public class Sort
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool isSelected { get; set; }
        public string url { get; set; }
    }

    public class NewsResult
    {
        [JsonProperty(PropertyName = "name")]
        public string Headline { get; set; }
        public string Url { get; set; }
        public Image Image { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Summary { get; set; }
        public List<About> About { get; set; }
        public List<Provider> Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
        public string SentimentScore { get; set; }
    }

    public class Image
    {
        public Thumbnail Thumbnail { get; set; }
    }

    public class Thumbnail
    {
        public string ContentUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class About
    {
        public string ReadLink { get; set; }
        public string Name { get; set; }
    }

    public class Provider
    {
        [JsonProperty(PropertyName = "_type")]
        public string Type { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
    }
}
      
