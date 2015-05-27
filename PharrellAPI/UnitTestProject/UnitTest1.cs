using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TweetinviProvider;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //arrange 
            TweetinviFacade tweetFacade = new TweetinviFacade();
            //act
            tweetFacade.GetATweet();

            //assert
        }
    }
}
