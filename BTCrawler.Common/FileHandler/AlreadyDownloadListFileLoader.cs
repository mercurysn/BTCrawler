using System.Collections.Generic;
using System.IO;

namespace BTCrawler.Common.FileHandler
{
    public class AlreadyDownloadListFileLoader : IAlreadyDownloadListFileLoader
    {
        public List<string> LoadListFromFile(string filename)
        {
            return new List<string>(File.ReadAllLines(filename));
        }
    }
}
