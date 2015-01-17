using System.Net;
using NUnit.Framework;

namespace Crawler.UnitTests
{
    [TestFixture]
    public class HtmlLoaderIntegrationTests
    {
        [Test, Explicit]
        public void Test()
        {
            WebProxy proxy = new WebProxy("proxy", true)
                                 {
                                     Credentials = new NetworkCredential("PINPOINT\\SimonN", "bdfkmmnry101A!")
                                 };
            WebRequest.DefaultWebProxy = proxy;
            WebClient client = new WebClient {Proxy = proxy};


            string Html = client.DownloadString(@"http://tvboxnow.com/thread-3119030-1-1.html");
        }
    }
}
