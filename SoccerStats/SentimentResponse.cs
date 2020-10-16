using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoccerStats
{
    public class SentimentResponse
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Sentiment> Sentiments { get; set; }
    }

    public class Sentiment
    {
        public string Id { get; set; }
        public string MainSentiment { get; set; }
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
