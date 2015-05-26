```
var authHeader = new OAuthBasicAuthenticationHeader("YtuEfT6GTCJl9BJ9zYFpMsz3X", "5so8XZvH0Prxitzp3inM5AdbNak8a83NhJCHT9xD9POoQohzk7");
var tokenFetcher = new TwitterOAuthTokenFetcher(authHeader);
TwitterAuthenticationResponse token = await tokenFetcher.ObtainToken();
if (token != null)
{
    TwitterTweetFetcher tweetFetcher = new TwitterTweetFetcher(token);
    TwitterSearchResponse tweets = await tweetFetcher.Search(174.7772m, -41.2889m, 100, "recent", 100);
}
```