using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
namespace DemoProject
{
    [TestClass]
    public class ChromeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private IWebDriver _driver;
        private YahooFinancePage _yahooFinancePage;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            _driver = new ChromeDriver(@"C:\Users\skumar20\source\repos\DemoProject\DemoProject\bin\Debug\netcoreapp2.1");
            _driver.Url = "https://finance.yahoo.com/lookup";
            //_driver.Manage().Window.FullScreen();
            _yahooFinancePage = new YahooFinancePage(_driver);
          
        }

        [TestMethod]

        public void MSFT()
        {
            _yahooFinancePage.NavigatetoStock("MSFT");
            _yahooFinancePage.NavigateToSpecificTab("Analysis");
            _yahooFinancePage.GetRecommendationRating();
            var low = _yahooFinancePage.GetAnalysisPrice("Low");
            var high = _yahooFinancePage.GetAnalysisPrice("High");
            var avg = _yahooFinancePage.GetAnalysisPrice("Average");
            var curr = _yahooFinancePage.GetAnalysisPrice("Current");
            
        }

        [TestMethod]

        public void AAPL()
        {
            _yahooFinancePage.NavigatetoStock("AAPL");
            _yahooFinancePage.NavigateToSpecificTab("Analysis");
            _yahooFinancePage.GetRecommendationRating();
            //low
            var low = _yahooFinancePage.GetAnalysisPrice("Low");
            //high
            var high = _yahooFinancePage.GetAnalysisPrice("High");
            //average
            var avg = _yahooFinancePage.GetAnalysisPrice("Average");
            //current
            var curr = _yahooFinancePage.GetAnalysisPrice("Current");

        }

        [TestMethod]

        public void FB()
        {
            _yahooFinancePage.NavigatetoStock("FB");
            _yahooFinancePage.NavigateToSpecificTab("Analysis");
            _yahooFinancePage.GetRecommendationRating();
            var low = _yahooFinancePage.GetAnalysisPrice("Low");
            var high = _yahooFinancePage.GetAnalysisPrice("High");
            var avg = _yahooFinancePage.GetAnalysisPrice("Average");
            var curr = _yahooFinancePage.GetAnalysisPrice("Current");

        }

        [TestMethod]

        public void GOOG()
        {
            _yahooFinancePage.NavigatetoStock("GOOG");
            _yahooFinancePage.NavigateToSpecificTab("Analysis");
            _yahooFinancePage.GetRecommendationRating();
            var low = _yahooFinancePage.GetAnalysisPrice("Low");
            var high = _yahooFinancePage.GetAnalysisPrice("High");
            var avg = _yahooFinancePage.GetAnalysisPrice("Average");
            var curr = _yahooFinancePage.GetAnalysisPrice("Current");

        }

        [TestMethod]

        public void NVDA()
        {
            _yahooFinancePage.NavigatetoStock("NVDA");
            _yahooFinancePage.NavigateToSpecificTab("Analysis");
            _yahooFinancePage.GetRecommendationRating();
            var low = _yahooFinancePage.GetAnalysisPrice("Low");
            var high = _yahooFinancePage.GetAnalysisPrice("High");
            var avg = _yahooFinancePage.GetAnalysisPrice("Average");
            var curr = _yahooFinancePage.GetAnalysisPrice("Current");

        }


        [TestCleanup]

        public void Close()
        {
            _driver.Quit();
        }
        
    }
}
