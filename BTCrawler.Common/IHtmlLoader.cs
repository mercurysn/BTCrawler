namespace BTCrawler.Common
{
    public interface IHtmlLoader
    {
        string LoadSource();
        string LoadSource(string url);
    }
}