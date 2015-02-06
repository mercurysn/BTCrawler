using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BTCrawler.Common.Crawler
{
    public class ListingPageCrawler
    {
        private string _htmlText { get; set; }

        public ListingPageCrawler(IHtmlLoader loader)
        {
            _htmlText = loader.LoadSource();
        }

        public List<DownloadLink> GetLinks()
        {
            return ConstructDownloadLinkCollection();
        }

        private List<DownloadLink> ConstructDownloadLinkCollection()
        {
            var matches = Regex.Matches(_htmlText, @"<span onmouseover=""sh(.*)</a></span>+");

            //var matches = Regex.Matches(_htmlText, @"<span onmouseover=""([A-Za-z0-9%<>&;\??\/.,:\""=\- ()_\p{L}]+)</span>");

            if (matches.Count == 0)
            {
                matches = Regex.Matches(_htmlText, @"<a([A-Za-z0-9%<>&;\?\/\.,:\""=\- ()_\p{L}]+)href=""attachment.php\?aid=([A-Za-z0-9%<>&;\?\/\.,:\""=\- ()_\p{L}]+)torrent</a>");
            }

            List<DownloadLink> downloadLinkCollection = new List<DownloadLink>();

            foreach (Match match in matches)
            {
                if (match == null)
                    return new List<DownloadLink>();

                var linkMatch = GetLinkMatch(match);

                var nameMatch = GetNameMatch(match);

                if (BreakOutDoNotAdd(nameMatch)) break;

                DownloadLink matchLink = new DownloadLink
                                             {
                                                 Url = linkMatch,
                                                 Name = nameMatch
                                             };

                downloadLinkCollection.Add(matchLink);
            }

            return downloadLinkCollection;
        }

        private static bool BreakOutDoNotAdd(string nameMatch)
        {
            return nameMatch.Contains("DIVX");
        }

        private static string GetNameMatch(Match match)
        {
            var nameMatches = Regex.Matches(match.ToString(), @"<strong>([A-Za-z0-9%<>&;\??\/., _:\""=()\p{L}]+)</strong>");

            string nameMatch;

            if (nameMatches.Count > 0)
                nameMatch = nameMatches[0].ToString().Replace("<strong>", "").Replace("</strong>", "");
            else
            {
                nameMatches = Regex.Matches(match.ToString(), @">([A-Za-z0-9%<>&;\??\/.,\- _:\""=()\p{L}]+)torrent<");
                nameMatch = nameMatches[0].ToString().Replace(">", "").Replace("<", "");
            }

            return nameMatch;
        }


        private static string GetLinkMatch(Match match)
        {
            var linkMatches = Regex.Matches(match.ToString(), @"attachment.php?([A-Za-z0-9%<&;\??\/.,:=()\p{L}]+)");

            if (linkMatches.Count == 0)
                return "";

            var linkMatch = linkMatches[0].ToString().Replace("\"", "");
            return string.Format("http://tvboxnow.com/{0}", linkMatch);
        }
    }
}
