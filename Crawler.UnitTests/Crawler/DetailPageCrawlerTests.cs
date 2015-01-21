using BTCrawler.Common;
using BTCrawler.Common.Crawler;
using Moq;
using NUnit.Framework;

namespace Crawler.UnitTests.Crawler
{
    [TestFixture]
    public class DetailPageCrawlerTests
    {
        private readonly Mock<IHtmlLoader> _mockLoader = new Mock<IHtmlLoader>();

        [SetUp]
        public void Setup()
        {
            _mockLoader.Setup(x => x.LoadSource()).Returns(MockHtmlSource.DetailPageHtml);
        }

        [Test]
        public void TestCrawler_Listing_Page_Retrieve_Links()
        {
            DetailPageCrawler crawler = new DetailPageCrawler(_mockLoader.Object);

            DownloadLink downloadLink = crawler.GetLink();

            Assert.AreEqual("attachment.php?aid=3009378&k=7fc12ad772cdf653bde8848d5bb8941d&t=1421246436&ck=2b7ad64d&sid=e8f32L3Q9Lyajbzrrzn87VxGMZYBFGepfBynzZrc4wylFaA", downloadLink.Url);
        }

        [Test]
        public void TestCrawler_Listing_Page_Retrieve_Links_No_Link_Found_Should_No_Errors()
        {
            _mockLoader.Setup(x => x.LoadSource()).Returns("");

            DetailPageCrawler crawler = new DetailPageCrawler(_mockLoader.Object);

            crawler.GetLink();
        }
    }
    
}
