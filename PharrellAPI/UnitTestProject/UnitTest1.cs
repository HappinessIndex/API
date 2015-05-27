using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PharrellAPI.Models;
using TweetinviProvider;

namespace UnitTestProject
{
    [TestFixture]
    public class TweetInviProviderGetTweets
    {
        [Test]
        public void TestMethod1()
        {
            //arrange 
            TweetinviFacade tweetFacade = new TweetinviFacade();
            //act
            tweetFacade.GetTweets();

            //assert
        }
    }

    [TestFixture]
    public class PharellAPItests
    {
        [Test]
        public void StoreTweetsToDb()
        {
            //arrange 
            StoreTweets storeTweets = new StoreTweets();
            //act
            storeTweets.SaveTweetsToDb();

            //assert
        }
    }
}
