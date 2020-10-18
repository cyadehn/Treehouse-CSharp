using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoccerStats
{
    public class SentimentResponse
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Response> Responses { get; set; }
    }

    public class Response
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "sentiment")]
        public string MainSentiment { get; set; }
        [JsonProperty(PropertyName = "confidenceScores")]
        public ConfidenceScores ConfidenceScores { get; set; }
    }

    public class ConfidenceScores
    {
        [JsonProperty(PropertyName = "positive")]
        public string Positive { get; set; }
        [JsonProperty(PropertyName = "neutral")]
        public string Neutral { get; set; }
        [JsonProperty(PropertyName = "negative")]
        public string Negative { get; set; }
    }
}
