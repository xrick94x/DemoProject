using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace DemoProject
{
    public class YahooFinancePage
    {
        public IWebDriver _driver = null;
        public YahooFinancePage(IWebDriver driver)
        {
            this._driver = driver;
        }
        public IWebElement searchBox()
        {
            return this._driver.FindElement(By.XPath("//input[@id='yfin-usr-qry']"));
        }

        public IWebElement stockList()
        {
            return this._driver.FindElement(By.XPath("//div[@srchresult='true']//div[@class='modules_suggestionList__NNFY0']//ul[1]"));
        }

        ////div[@id='quote-nav']//li//a//span[text()='Analysis']

        public IWebElement quoteNavigator()
        {
            return this._driver.FindElement(By.XPath("//div[@id='quote-nav']"));
        }


        // //section[@data-test='recommendation-rating']//div[@data-test='rec-rating-txt']
        public IWebElement recommendationRating()
        {
            return this._driver.FindElement(By.XPath("//div[@data-test='rec-rating-txt']"));
        }

        // //div[@data-test='quote-mdl']//div[contains(@aria-label,'Low')]//span[text()='High']/following-sibling::span

        public IWebElement analysisPriceTargets()
        {
            return this._driver.FindElement(By.XPath("//div[@data-test='quote-mdl']//div[contains(@aria-label,'Low')]"));
        }

        public void NavigatetoStock(string stockName)
        {
            //div[@srchresult='true']//div[@class='modules_suggestionList__NNFY0']//ul//li//div[text()='MSFT']
            //HandlePopup();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));                      
            searchBox().SendKeys(stockName);
            var listBox = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@srchresult='true']//div[@class='modules_suggestionList__NNFY0']//ul")));
            //Thread.Sleep(5000);
            var _element = wait.Until(ExpectedConditions.ElementExists(By.XPath("//li//div[text()='"+stockName+"']/..")));
            _element.Click();
            var watchlist = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Add to watchlist']")));
            Assert.IsTrue(watchlist.Displayed, "Analysis page is not displayed");

        }

        public void HandlePopup()
        {
            if (_driver.FindElement(By.XPath("//div[@id='myLightboxContainer']//button")).Displayed)
            {
                _driver.FindElement(By.XPath("//div[@id='myLightboxContainer']//button")).Click();
            }
            else { return; }
        }

        public void NavigateToSpecificTab(string tabName)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var watchlist = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//span[text()='Add to watchlist']")));
            //li//a//span[text()='Analysis']
            var tab = quoteNavigator().FindElement(By.XPath(".//li//a//span[text()='"+tabName+"']"));
            tab.Click();
            var earningElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Earnings Estimate']")));
            Assert.IsTrue(earningElement.Displayed, "Analysis Tab has not been clicked");
        }


        public void GetRecommendationRating()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            var text = recommendationRating().Text;
            Console.WriteLine(text);
        }

        public string GetAnalysisPrice(string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            var price = analysisPriceTargets().FindElement(By.XPath(".//span[text()='" + value + "']/following-sibling::span")).Text;
            Console.WriteLine(price);
            return price;
        }

    }
}



