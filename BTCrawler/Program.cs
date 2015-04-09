using System;
using System.Collections.Generic;
using BTCrawler.Common;
using BTCrawler.Common.FileHandler;


namespace BTCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string listingPageUrlFilePath = @"C:\Users\Mercury\Dropbox\Android Download\To Be Downloaded.txt";
            string outputFilePath = @"C:\Users\Mercury\Dropbox\Android Download";
            string alreadyDownloadedFileName = @"C:\Users\Mercury\Dropbox\Android Download\Downloaded.txt";

            //string listingPageUrlFilePath = args[0];
            //string outputFilePath = args[1];
            //string alreadyDownloadedFileName = args[2];

            Action<string> writeMessage = x => Console.WriteLine(x);

            List<string> listingUrls = ListingUrlFileLoader.GetListingPageUrls(listingPageUrlFilePath);

            foreach (string url in listingUrls)
            {
                IAlreadyDownloadListFileLoader fileLoader = new AlreadyDownloadListFileLoader();
                IHtmlLoader listingPageLoader = new SeleniumHtmlLoader(url, "mercurysn", "123ert");
                IHtmlLoader detailPageLoader = new SeleniumHtmlLoader("", "mercurysn", "123ert");

                Controller controller = new Controller(fileLoader, listingPageLoader, detailPageLoader, outputFilePath, writeMessage);

                controller.DoDownload(alreadyDownloadedFileName);
            }
        }
    }
}
