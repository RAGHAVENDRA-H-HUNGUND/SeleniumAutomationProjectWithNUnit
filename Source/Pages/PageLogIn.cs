using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationProjectWithNUnit.Utilities;

namespace SeleniumAutomationProjectWithNUnit.Source.Pages
{
    public class PageLogIn
    {
        private IWebDriver _driver;

        private IWebElement Username =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("username")));

        private IWebElement Password =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("password")));

        private IWebElement Loginbtn =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit']")));

        public IWebElement InvalidCredential =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Invalid credentials']")));

        public IWebElement UsernameRequiredFieldMsg =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@name='username']/following::span")));

        public IWebElement PasswordRequiredFieldMsg =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@name='password']/following::span")));
        
        public PageLogIn(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.BaseUrl);
        }

        public void LogIn(string userName, string password)
        {   
            Username.Clear();
            Username?.SendKeys(userName);
            Password.Clear();
            Password?.SendKeys(password);
            Loginbtn?.Click();
        }
    }
}
