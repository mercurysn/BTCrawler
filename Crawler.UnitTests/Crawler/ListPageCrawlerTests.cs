using System.Collections.Generic;
using BTCrawler.Common;
using BTCrawler.Common.Crawler;
using Moq;
using NUnit.Framework;

namespace Crawler.UnitTests.Crawler
{
    [TestFixture]
    public class ListPageCrawlerTests
    {
        private Mock<IHtmlLoader> _mockLoader = new Mock<IHtmlLoader>();

        [SetUp]
        public void Setup()
        {
            _mockLoader.Setup(x => x.LoadSource()).Returns(MockHtmlSource.ListPageHtml);
        }

        [Test]
        public void TestCrawler_Listing_Page_Retrieve_Links()
        {
            ListingPageCrawler crawler = new ListingPageCrawler(_mockLoader.Object);

            List<DownloadLink> downloadLinkCollection = crawler.GetLinks();

            Assert.AreEqual("attachment.php?aid=3009378&amp;k=5eee5ec8df127f2f097b12e37c816161&amp;t=1421246568&amp;sid=0c45wEiE3wE8%2FBFNRYfCl8ibzt1BCx%2F%2Fx3caKvtv3Gpb50c", downloadLinkCollection[0].Url);
            Assert.AreEqual("TVBOXNOW 宦海奇官 Ch01_1280x720.torrent", downloadLinkCollection[0].Name);
            Assert.AreEqual("TVBOXNOW 宦海奇官 Ch02_1280x720.torrent", downloadLinkCollection[1].Name);
            Assert.AreEqual("TVBOXNOW 宦海奇官 Ch03_1280x720.torrent", downloadLinkCollection[2].Name);
        }

        [Test]
        public void TestCrawler_Listing_Page_Retrieve_No_Link_Dont_Throw_Exception()
        {
            _mockLoader.Setup(x => x.LoadSource()).Returns("");

            ListingPageCrawler crawler = new ListingPageCrawler(_mockLoader.Object);

            crawler.GetLinks();
        }
    }
}
