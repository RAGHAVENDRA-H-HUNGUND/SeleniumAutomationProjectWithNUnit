using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationProjectWithNUnit.Config;
using SeleniumAutomationProjectWithNUnit.Data;
using SeleniumAutomationProjectWithNUnit.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Tests
{
    [TestFixture]
    public class TestLogIn : ReportsGeneration
    {
        //private new ChromeDriver _driver;
        PageLogIn? pageLogin;
        
        [Test]
        [Retry(3)]
        public void SignIn()
        {
            pageLogin = new PageLogIn(GetDriver());
            _driver.Navigate().GoToUrl(TestUrl.Url);
            Thread.Sleep(5000);
            
            pageLogin.LogIn(TestDataForLogInPage.ValidUsername, TestDataForLogInPage.ValidPassword);
            Thread.Sleep(5000);
            //SelectElement select = new SelectElement();
            _driver.FindElement(By.XPath("//p[@class='oxd-userdropdown-name']")).Click();
            //select.SelectByValue("Logout");
            _driver.FindElement(By.XPath("//*[@id='app']/div[1]/div[1]/header/div[1]/div[3]/ul/li/ul/li[4]/a")).Click();
            
        }

        [Test]
        [Retry(3)]
        public void LogInWithWrongCredentials()
        {
            pageLogin = new PageLogIn(GetDriver());
            _driver.Navigate().GoToUrl(TestUrl.Url);
            Thread.Sleep(5000);
            pageLogin.LogIn(TestDataForLogInPage.InvalidUsername, TestDataForLogInPage.InvalidPassword);
            Thread.Sleep(5000);
            
            IWebElement e = _driver.FindElement(By.XPath("//*[text()='Invalid credentials']"));
            
            Assert.That(e.Text, Is.EqualTo(TestDataForLogInPage.InvalidCredentialsMessage));
            
        }

        [Test]
        [Retry(3)]
        public void LogInWithEmptyUserName()
        {
            pageLogin = new PageLogIn(GetDriver());
            _driver.Navigate().GoToUrl(TestUrl.Url);
            Thread.Sleep(5000);            
            pageLogin.LogIn(TestDataForLogInPage.EmptyUsername, TestDataForLogInPage.InvalidPassword);
            Thread.Sleep(5000);

            IWebElement e = _driver.FindElement(By.XPath("//*[@name='username']/following::span"));

            Assert.That(e.Text, Is.EqualTo(TestDataForLogInPage.RequiredFieldMessage));
        }

        [Test]
        public void LogInWithEmptyPassword()
        {
            pageLogin = new PageLogIn(GetDriver());
            _driver.Navigate().GoToUrl(TestUrl.Url);
            Thread.Sleep(5000);
            pageLogin.LogIn(TestDataForLogInPage.ValidUsername, TestDataForLogInPage.EmptyPassword);
            Thread.Sleep(5000);

            IWebElement e = _driver.FindElement(By.XPath("//*[@name='password']/following::span"));

            Assert.That(e.Text, Is.EqualTo(TestDataForLogInPage.RequiredFieldMessage));
            
        }

        [Test]
        [Retry(3)]
        public void LogInWithEmptyFields()
        {
            pageLogin = new PageLogIn(GetDriver());
            _driver.Navigate().GoToUrl(TestUrl.Url);
            Thread.Sleep(5000);

            pageLogin.LogIn(TestDataForLogInPage.EmptyUsername, TestDataForLogInPage.EmptyPassword);
            Thread.Sleep(5000);

            IWebElement e1 = _driver.FindElement(By.XPath("//*[@name='username']/following::span"));
            IWebElement e2 = _driver.FindElement(By.XPath("//*[@name='password']/following::span"));
            Assert.Multiple(() =>
            {
                Assert.That(e1.Text, Is.EqualTo(TestDataForLogInPage.RequiredFieldMessage));
                Assert.That(e2.Text, Is.EqualTo(TestDataForLogInPage.RequiredFieldMessage));
            });
            
        }
    }
}
