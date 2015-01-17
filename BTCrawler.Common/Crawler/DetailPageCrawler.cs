using System.Text.RegularExpressions;

namespace BTCrawler.Common.Crawler
{
    public class DetailPageCrawler
    {
        private string _htmlText { get; set; }

        public DetailPageCrawler(IHtmlLoader loader)
        {
            _htmlText = loader.LoadSource();
        }

        public DetailPageCrawler(IHtmlLoader loader, string url)
        {
            _htmlText = loader.LoadSource(url);
        }

        public DownloadLink GetLink()
        {
            return ConstructDownloadLinkCollection();
        }

        private DownloadLink ConstructDownloadLinkCollection()
        {
            var matches = Regex.Matches(_htmlText, @"<a href=""attachment.php\?aid=([A-Za-z0-9%<>&;\??\/.,:\""= ()_\p{L}]+)"">");

            return new DownloadLink
                       {
                           Url = matches[0].ToString().Replace("<a href=\"", "").Replace(">","").Replace("\"", "")
                       };

        }
    }
}
