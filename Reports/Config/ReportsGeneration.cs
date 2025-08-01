using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumAutomationProjectWithNUnit.Helpers;
using SeleniumAutomationProjectWithNUnit.Managers;
using SeleniumAutomationProjectWithNUnit.Utilities;

namespace SeleniumAutomationProjectWithNUnit.Reports.Config
{
    public class ReportsGeneration
    {
        [ThreadStatic]
        public static IWebDriver driver;

        protected ExtentReports _extent;
        protected ThreadLocal<ExtentTest> _test = new();
        private BrowserType _browser = BrowserType.Chrome;
        public string excelPath;
        public List<Dictionary<string, string>> testData;

        [OneTimeSetUp]
        protected void Setup()
        {
            _extent = ExtentManager.GetExtent();
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            _test.Value = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver = DriverFactory.GetDriver(_browser);
            string baseDirectory = TestContext.CurrentContext.TestDirectory;
            excelPath = Path.Combine(baseDirectory, "TestData", "TestData.xlsx");
            testData = ExcelReader.ReadExcel(excelPath, "LoginData");

        }

        [TearDown]
        public void AfterTest()
        {
            var result = TestContext.CurrentContext.Result;
            var status = result.Outcome.Status;
            var message = result.Message;
            var stacktrace = result.StackTrace ?? "";

            Status logstatus = status switch
            {
                TestStatus.Failed => Status.Fail,
                TestStatus.Passed => Status.Pass,
                TestStatus.Skipped => Status.Skip,
                TestStatus.Inconclusive => Status.Info,
                TestStatus.Warning => Status.Warning,
                _ => Status.Info
            };

            if (status is TestStatus.Passed or TestStatus.Failed)
            {
                string screenshot = ScreenshotHelper.Capture(driver, _test.Value.Test.FullName, logstatus);
                _test.Value.Log(logstatus, status.ToString());
                _test.Value.AddScreenCaptureFromPath(screenshot);
            }

            _test.Value.Log(logstatus, $"Test ended with {logstatus}\n{stacktrace}\n{message}");
            _extent.Flush();
            driver.Quit();
 
        }        
    }
}
