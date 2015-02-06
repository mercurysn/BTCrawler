using System.Net;
using System.Text;

namespace BTCrawler.Common
{
    public class HtmlLoader : IHtmlLoader
    {
        public HtmlLoader()
        {

        }

        public HtmlLoader(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public string LoadSource()
        {
            return LoadSource(Url);
        }

        public string LoadSource(string url)
        {
            using (WebClient client = new WebClient { Encoding = Encoding.UTF8}) // WebClient class inherits IDisposable
            {
                return client.DownloadString(url);
            }
        }
    }
}
