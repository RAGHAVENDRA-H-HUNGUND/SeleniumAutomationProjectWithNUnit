using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumAutomationProjectWithNUnit.Utilities.ReportUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Utilities
{
    public class DriverUtility
    {
        //private IWebDriver driver;

        //public IWebDriver GetDriver(string browser)
        //{
        //    try
        //    {
        //        driver = SetDriver(browser);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(e.Message);
        //    }
        //    return driver;
        //}

        //private IWebDriver SetDriver(string browser)
        //{
        //    switch (browser.ToLower())
        //    {
        //        case "chrome":
        //            driver = InitChromeDriver();
        //            ReportLog.Pass("Chrome Initialized Successfully");
        //            break;
        //        case "firefox":
        //            driver = InitFirefoxDriver();
        //            ReportLog.Pass("Firefox Initialized Successfully");
        //            break;
        //        default:
        //            Assert.Fail("Invalid browser");
        //            break;
        //    }
        //    driver.Manage().Window.Maximize();
        //    return driver;
        //}

        //private IWebDriver InitChromeDriver() => new ChromeDriver();

        //private IWebDriver InitFirefoxDriver() => new FirefoxDriver();

    }
}
