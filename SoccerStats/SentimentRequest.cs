﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoccerStats
{
    public class SentimentRequest
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Document> Documents { get; set; }
    }

    public class Document
    {
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; } = "en";
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
