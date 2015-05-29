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
        [JsonIgnore]
        public int SentimentValue { get; set; }
        [JsonIgnore]
        public virtual Tweet Tweet { get; set; }
    }

    public class Sentiment
    {
        public Result result { get; set; }
    }
}