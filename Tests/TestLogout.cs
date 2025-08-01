using OpenQA.Selenium;
using SeleniumAutomationProjectWithNUnit.Helpers;
using SeleniumAutomationProjectWithNUnit.Reports.Config;
using SeleniumAutomationProjectWithNUnit.Source.Pages;
using SeleniumAutomationProjectWithNUnit.Utilities;

namespace SeleniumAutomationProjectWithNUnit.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Edge)]
    [Parallelizable(ParallelScope.Self)]
    public class TestLogout : ReportsGeneration
    {
        [ThreadStatic]
        public static IWebDriver driver;

        private readonly BrowserType _browser;
        PageDashboard? pageDashboard;
        private string excelPath;
        List<Dictionary<string, string>> testData;
        public string username, password, expectedResult;

        public TestLogout(BrowserType browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.GetDriver(_browser);
            string baseDirectory = TestContext.CurrentContext.TestDirectory;
            excelPath = Path.Combine(baseDirectory, "TestData", "TestData.xlsx");
            testData = ExcelReader.ReadExcel(excelPath, "LoginData");
        }

        [Test]
        public void LogOut()
        {
            username = testData[0]["UserName"];
            password = testData[0]["Password"];
            PageLogIn pageLogin = new PageLogIn(driver);
            pageLogin.NavigateToLoginPage(); 
            pageLogin.LogIn(username, password);
            pageDashboard = new PageDashboard(driver);
            pageDashboard.Logout();
        }
    }
}
