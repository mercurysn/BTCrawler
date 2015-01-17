using System.Collections.Generic;
using BTCrawler.Common.Crawler;
using BTCrawler.Common.FileHandler;

namespace BTCrawler.Common
{
    public class Controller
    {
        private readonly IAlreadyDownloadListFileLoader _alreadyDownloadListFileLoader;
        private readonly IHtmlLoader _detailPageLoader;
        private readonly IHtmlLoader _listingPageloader;

        public Controller(IAlreadyDownloadListFileLoader alreadyDownloadListFileLoader, IHtmlLoader listingPageLoader, IHtmlLoader detailPageLoader)
        {
            _alreadyDownloadListFileLoader = alreadyDownloadListFileLoader;
            _detailPageLoader = detailPageLoader;
            _listingPageloader = listingPageLoader;
        }

        public void DoDownload(string alreadyDownloadedListFileName)
        {
            List<string> alreadyDownloadedList = _alreadyDownloadListFileLoader.LoadListFromFile(alreadyDownloadedListFileName);

            ListingPageCrawler listingPageCrawler = new ListingPageCrawler(_listingPageloader);

            var links = listingPageCrawler.GetLinks();

            foreach (var link in links)
            {
                
                DetailPageCrawler detailPageCrawler = new DetailPageCrawler(_detailPageLoader, link.Url);

                DownloadLink detailLink = detailPageCrawler.GetLink();

                if (!alreadyDownloadedList.Contains(detailLink.Name))
                {
                    HtmlSourceDownloader downloader = new HtmlSourceDownloader();

                    
                }
            }
        }
    }
}
