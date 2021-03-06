﻿using System;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace BTCrawler.Common
{
    public class HtmlSourceDownloader
    {
        public bool DownloadFile(string url, string outputPath, int preference = 1)
        {
            //using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            //{
            //    client.DownloadFile(url, string.Format(@"{0}\{1}.torrent", outputPath, Guid.NewGuid()));
            //}

            FirefoxProfile firefoxProfile = new FirefoxProfile();

            firefoxProfile.SetPreference("browser.download.folderList", 2);
            //firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);
            firefoxProfile.SetPreference("browser.download.dir", outputPath);

            if (preference % 2 == 1)
                firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-bittorrent");
            else
                firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/force-download");
            //firefoxProfile.SetPreference("browser.helperApps.alwaysAsk.force", false);
            //firefoxProfile.SetPreference("browser.download.manager.showWhenStarting", false);

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
