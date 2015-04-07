using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BTCrawler.Common.Crawler;
using BTCrawler.Common.FileHandler;

namespace BTCrawler.Common
{
    public class Controller
    {
        private readonly IAlreadyDownloadListFileLoader _alreadyDownloadListFileLoader;
        private readonly IHtmlLoader _detailPageLoader;
        private readonly IHtmlLoader _listingPageloader;
        private readonly string _outputPath;
        private readonly Action<string> _writeMessage;

        public Controller(IAlreadyDownloadListFileLoader alreadyDownloadListFileLoader, IHtmlLoader listingPageLoader, IHtmlLoader detailPageLoader, string outputPath, Action<string> writeMessage)
        {
            _alreadyDownloadListFileLoader = alreadyDownloadListFileLoader;
            _detailPageLoader = detailPageLoader;
            _listingPageloader = listingPageLoader;
            _outputPath = outputPath;
            _writeMessage = writeMessage;
        }

        public void DoDownload(string alreadyDownloadedListFileName)
        {
            List<string> alreadyDownloadedList = _alreadyDownloadListFileLoader.LoadListFromFile(alreadyDownloadedListFileName);

            ListingPageCrawler listingPageCrawler = new ListingPageCrawler(_listingPageloader);

            var links = listingPageCrawler.GetLinks();

            foreach (var link in links)
            {
                //DetailPageCrawler detailPageCrawler = new DetailPageCrawler(_detailPageLoader, link.Url);

                //DownloadLink detailLink = detailPageCrawler.GetLink();

                if (!alreadyDownloadedList.Contains(link.Name) && !link.Name.ToLower().Contains("divx"))
                {
                    int retryCount = 0;

                    HtmlSourceDownloader downloader = new HtmlSourceDownloader();

                    while (!File.Exists(_outputPath + @"\" + link.Name) && retryCount < 10)
                    {
                        downloader.DownloadFile(link.Url, _outputPath);

                        retryCount++;
                    }

                    if (File.Exists(_outputPath + @"\" + link.Name))
                    {
                        _writeMessage(string.Format("Downloaded file {0}", link.Name));

                        File.AppendAllText(alreadyDownloadedListFileName, link.Name + Environment.NewLine, Encoding.UTF8);
                        File.AppendAllText(alreadyDownloadedListFileName, link.Name.Replace("_1280x720", "") + Environment.NewLine, Encoding.UTF8);
                    }
                }
                else
                {
                    _writeMessage(string.Format("Already downloaded: {0}", link.Name));
                }
            }
        }
    }
}
