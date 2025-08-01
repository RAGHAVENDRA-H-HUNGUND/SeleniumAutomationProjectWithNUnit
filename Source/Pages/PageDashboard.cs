using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationProjectWithNUnit.Utilities;
using SeleniumExtras.PageObjects;

namespace SeleniumAutomationProjectWithNUnit.Source.Pages
{
    public class PageDashboard
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private IWebElement? AttendanceIcon => new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By
                .XPath("//button[@type='button']/child::i[@class='oxd-icon bi-stopwatch']")));
                     
        private IWebElement LogoutMenu =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By
            .XPath("//img[@alt='profile picture']/following-sibling::i")));

        private IWebElement LogoutOption =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By
            .XPath("//*[@id='app']/div[1]/div[1]/header/div[1]/div[3]/ul/li/ul/li[4]/a")));
        
        public PageDashboard(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Logout()
        {
            LogoutMenu?.Click();
            LogoutOption?.Click();
        }

        public bool IsAtDashboard()
        {
           return _driver.Url.Contains("dashboard");
        }
    }
}
