using System.Collections.Generic;

namespace BTCrawler.Common.FileHandler
{
    public interface IAlreadyDownloadListFileLoader
    {
        List<string> LoadListFromFile(string filename);
    }
}