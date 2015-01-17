using System.Collections.Generic;

namespace BTCrawler.Common.FileHandler
{
    public class AlreadyDownloadListFileLoader : IAlreadyDownloadListFileLoader
    {
        public List<string> LoadListFromFile(string filename)
        {
            return new List<string>();
        }
    }
}
