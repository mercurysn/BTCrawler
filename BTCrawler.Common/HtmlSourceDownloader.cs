using System;
using System.Net;

namespace BTCrawler.Common
{
    public class HtmlSourceDownloader
    {
        public bool DownloadFile(string url, string outputPath)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                client.DownloadFile(url, string.Format(@"{0}\{1}.torrent", outputPath, Guid.NewGuid()));
            }

            return true;
        }
    }
}
