using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InterfacesAndPOCOs;
using Newtonsoft.Json;

namespace PharrellAPI.Models
{
    public class SentimentStuff
    {
        public int Id { get; set; }
        public string confidence { get; set; }
        public string sentiment { get; set; }
    }

    public class Result
    {
        [JsonIgnore]
        public int Id { get; set; }
        public float confidence { get; set; }
        public string sentiment { get; set; }
        public Tweet TweetId { get; set; }
        
    }

    public class Sentiment
    {
        public Result result { get; set; }
    }
}