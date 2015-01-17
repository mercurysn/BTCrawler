using System.Collections.Generic;
using BTCrawler.Common.FileHandler;
using Moq;
using NUnit.Framework;

namespace Crawler.UnitTests
{
    [TestFixture]
    public class EndToEndTests
    {
        private readonly Mock<IAlreadyDownloadListFileLoader> downloadedFileLoader = new Mock<IAlreadyDownloadListFileLoader>();

        [SetUp]
        public void Setup()
        {
            List<string> mockAlreadyDownloadedList = new List<string>
                                                         {
                                                             "TVBOXNOW 宦海奇官 Ch01_1280x720.torrent",
                                                             "TVBOXNOW 宦海奇官 Ch02_1280x720.torrent"
                                                         };
            downloadedFileLoader.Setup(x => x.LoadListFromFile(It.IsAny<string>())).Returns(mockAlreadyDownloadedList);
        }

        [Test]
        public void EndToEndTest()
        {
            
        }
    }
}
