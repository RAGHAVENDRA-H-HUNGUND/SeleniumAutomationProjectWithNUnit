using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Source.Pages
{
    public class PageLogIn
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "username")]
        private readonly IWebElement _username;

        [FindsBy(How = How.Name, Using = "password")]
        private readonly IWebElement _password;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private readonly IWebElement _loginbtn;

        //[FindsBy(How = How.XPath, Using = "//*[@name='username']/following::span")]
        //private readonly IWebElement _usernamerequiredfieldmsg;

        //[FindsBy(How = How.XPath, Using = "//*[@name='password']/following::span")]
        //public string? _passwordrequiredfieldmsg;

        public PageLogIn(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogIn(string userName, string password)
        {
            _username?.SendKeys(userName);
            _password?.SendKeys(password);
            _loginbtn?.Click();
        }
    }
}
