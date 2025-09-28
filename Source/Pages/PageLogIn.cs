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
            try
            {
                Username?.SendKeys(userName);
                Thread.Sleep(10000);//rameshragadi9@gmail.com
                Password.Clear();
                Password?.SendKeys(password);
                Loginbtn?.Click();
            }            
            
            catch(NoSuchElementException ex) {
                TestContext.WriteLine($"Login element not found: {ex.Message}");
                Assert.Fail($"Login element not found during valid login test: {ex.Message}");
            }

            catch (WebDriverTimeoutException ex)
            {
                // Handle timeout issues: log, screenshot, or fail
                TestContext.WriteLine($"WebDriver timeout during valid login test: {ex.Message}");
                Assert.Fail($"WebDriver timeout during valid login test: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                TestContext.WriteLine($"An unexpected error occurred during valid login test: {ex.Message}");
                Assert.Fail($"An unexpected error occurred: {ex.Message}");
            }
        }

        public bool AssertionWithActualExpectedResult(string actualResult, string expectedResult)
        {
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            return true;
        }

        public bool AssertionWithContains(bool condition)
        {
            Assert.IsTrue(condition);
            return true;
        }
    }
}
