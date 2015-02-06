using System;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace BTCrawler.Common
{
    public class HtmlSourceDownloader
    {
        public bool DownloadFile(string url, string outputPath)
        {
            //using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            //{
            //    client.DownloadFile(url, string.Format(@"{0}\{1}.torrent", outputPath, Guid.NewGuid()));
            //}

            FirefoxProfile firefoxProfile = new FirefoxProfile();

            firefoxProfile.SetPreference("browser.download.folderList", 2);
            //firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);
            firefoxProfile.SetPreference("browser.download.dir", outputPath);
            firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-bittorrent");

            IWebDriver driver = new FirefoxDriver(firefoxProfile);

            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Name("username")).SendKeys("mercurysn");
            driver.FindElement(By.Name("password")).SendKeys("123ert");

            driver.FindElement(By.Name("loginsubmit")).Click();

            Thread.Sleep(10000);

            driver.Dispose();

            return true;
        }
    }
}
