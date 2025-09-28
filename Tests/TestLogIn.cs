using OpenQA.Selenium;
using SeleniumAutomationProjectWithNUnit.Helpers;
using SeleniumAutomationProjectWithNUnit.Reports.Config;
using SeleniumAutomationProjectWithNUnit.Source.Pages;
using SeleniumAutomationProjectWithNUnit.Utilities;
using System.Data;

namespace SeleniumAutomationProjectWithNUnit.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Edge)]
    [Parallelizable(ParallelScope.Self)]
    public class TestLogIn : ReportsGeneration
    {
        private PageLogIn? pageLogin;
        private PageDashboard dashboardPage;
        private readonly BrowserType _browser;
        public string username, password, expectedResult;
        //private DatabaseHelper dbHelper;

        public TestLogIn(BrowserType browser)
        {
            _browser = browser;
        }

        [Test]
        [Retry(3)]
        public void SignIn()
        {
            LogHelper.Info($"Test: {_extent.CreateTest(TestContext.CurrentContext.Test.Name)} started.");
            username = testData[0]["UserName"];
            password = testData[0]["Password"];
            pageLogin = new PageLogIn(driver);

            LogHelper.Debug("Navigating to login page.");            
            pageLogin.NavigateToLoginPage();

            LogHelper.Info("Logging in with test credentials.");
            pageLogin.LogIn(username, password);
            
            //Assert.IsTrue(dashboardPage.IsAtDashboard(), "Login failed or not at Dashboard.");

            LogHelper.Info($"Test: {_extent.CreateTest(TestContext.CurrentContext.Test.Name)} passed.");

        }

        [Test]
        [Retry(3)]
        public void LogInWithWrongCredentials()
        {
            username = testData[1]["UserName"];
            password = testData[1]["Password"];
            expectedResult = testData[1]["Expected Result"];
            pageLogin = new PageLogIn(driver);
            pageLogin.NavigateToLoginPage();
            pageLogin.LogIn(username, password);

            //Assert.That(pageLogin.InvalidCredential.Text, Is.EqualTo(expectedResult));
            pageLogin.AssertionWithActualExpectedResult(pageLogin.InvalidCredential.Text, expectedResult);
        }

        [Test]
        [Retry(3)]
        public void LogInWithEmptyUserName()
        {
            username = testData[2]["UserName"];
            password = testData[2]["Password"];
            expectedResult = testData[2]["Expected Result"];
            pageLogin = new PageLogIn(driver);          
            pageLogin.NavigateToLoginPage();
            pageLogin.LogIn(username, password);

            //Assert.That(pageLogin.UsernameRequiredFieldMsg.Text, Is.EqualTo(expectedResult));
            pageLogin.AssertionWithActualExpectedResult(pageLogin.UsernameRequiredFieldMsg.Text, expectedResult);
        }

        [Test]
        public void LogInWithEmptyPassword()
        {
            username = testData[3]["UserName"];
            password = testData[3]["Password"];
            expectedResult = testData[3]["Expected Result"];
            pageLogin = new PageLogIn(driver);
            pageLogin.NavigateToLoginPage();
            pageLogin.LogIn(username, password);

            //Assert.That(pageLogin.PasswordRequiredFieldMsg.Text, Is.EqualTo(expectedResult));
            pageLogin.AssertionWithActualExpectedResult(pageLogin.PasswordRequiredFieldMsg.Text, expectedResult);

        }

        [Test]
        [Retry(3)]
        public void LogInWithEmptyFields()
        {
            username = testData[4]["UserName"];
            password = testData[4]["Password"];
            expectedResult = testData[4]["Expected Result"];
            pageLogin = new PageLogIn(driver);
            pageLogin.NavigateToLoginPage();            
            pageLogin.LogIn(username, password);
            
            Assert.Multiple(() =>
            {
                //Assert.That(pageLogin.UsernameRequiredFieldMsg.Text, Is.EqualTo(expectedResult));
                pageLogin.AssertionWithActualExpectedResult(pageLogin.UsernameRequiredFieldMsg.Text, expectedResult);
                //Assert.That(pageLogin.PasswordRequiredFieldMsg.Text, Is.EqualTo(expectedResult));
                pageLogin.AssertionWithActualExpectedResult(pageLogin.PasswordRequiredFieldMsg.Text, expectedResult);
            });
                        
        }
        
        [Test]
        public void Login_With_Valid_Credentials()
        {
            username = testData[0]["UserName"];
            password = testData[0]["Password"];
            //string query = "SELECT TOP 1 Username, Password FROM TestUsers";
            //DataTable dt = dbHelper.ExecuteQuery(query);

            //string username = dt.Rows[0]["Username"].ToString();
            //string password = dt.Rows[0]["Password"].ToString();

            pageLogin = new PageLogIn(driver);
            pageLogin.NavigateToLoginPage();
            pageLogin.LogIn(username, password);

            //Assert.IsTrue(driver.Url.Contains("dashboard")); // Example assertion
            pageLogin.AssertionWithContains(driver.Url.Contains("dashboard"));
        }
    }
}
