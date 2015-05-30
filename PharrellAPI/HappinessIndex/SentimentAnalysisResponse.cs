namespace HappinessIndex
{
    public class SentimentAnalysisResponse
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public float confidence { get; set; }
        public string sentiment { get; set; }
    }

        //[JsonIgnore]
        //public int SentimentValue { get; set; }
        //[JsonIgnore]
        //public virtual Tweet Tweet { get; set; }
}