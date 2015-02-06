using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCrawler.Common
{
    public static class ListingUrlFileLoader
    {
        public static List<string> GetListingPageUrls(string fileName)
        {
            List<string> LogList = new List<string>(File.ReadAllLines(fileName));

            List<string> returnUrlList = new List<string>();

            foreach (var logItem in LogList)
            {
                returnUrlList.Add(logItem.Split(',').First());
            }

            return returnUrlList;
        }
    }
}
