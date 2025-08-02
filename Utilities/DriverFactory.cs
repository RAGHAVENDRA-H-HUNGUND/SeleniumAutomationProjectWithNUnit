using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumAutomationProjectWithNUnit.Helpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomationProjectWithNUnit.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver(BrowserType browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    LogHelper.Info("Initializing FirefoxDriver.");
                    break;
                case BrowserType.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    LogHelper.Info("Initializing EdgeDriver.");
                    break;
                case BrowserType.Chrome:
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    LogHelper.Info("Initializing ChromeDriver.");
                    break;
            }

            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
