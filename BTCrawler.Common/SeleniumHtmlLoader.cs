using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace BTCrawler.Common
{
    public class SeleniumHtmlLoader : IHtmlLoader
    {
        public string Url { get; set; }
        private string _loginName;
        private string _password;

        public SeleniumHtmlLoader(string url, string username, string password)
        {
            Url = url;
            _loginName = username;
            _password = password;
        }

        public string LoadSource()
        {
            return LoadSource(Url);
        }

        public string LoadSource(string url)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Name("username")).SendKeys(_loginName);
            driver.FindElement(By.Name("password")).SendKeys(_password);

            driver.FindElement(By.Name("loginsubmit")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Url.ToLower().Equals(url); });

            string source = driver.PageSource;

            driver.Dispose();

            return source;
        }
    }
}
