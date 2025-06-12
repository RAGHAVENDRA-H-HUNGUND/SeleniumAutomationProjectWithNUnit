using AventStack.ExtentReports;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Net.NetworkInformation;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Gherkin.Model;
using SeleniumAutomationProjectWithNUnit;

using SeleniumAutomationProjectWithNUnit.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace SeleniumAutomationProjectWithNUnit.Config
{
    [SetUpFixture]
    public class ReportsGeneration : ScreenshotCleanup
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public IWebDriver _driver;

        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().Location;
            var actualPath = path[..path.LastIndexOf("bin")];
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);            

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
            
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            //ChromeDriverService service = ChromeDriverService.CreateDefaultService("webdriver.chrome.driver", @"D:\\Automation\\WebDrivers\\chromedriver.exe");
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _driver.Manage().Window.Maximize();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]

        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
                        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            string screenShotPath;
            var message = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + _test.Test.FullName + "_" + time.ToString("dd_MM_yyyy") + "_" + time.ToString("h_mm_ss") + ".png";
                    screenShotPath = Capture(_driver, fileName, logstatus);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    //_test.Log(Status.Info, "Screenshot: ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(".\\" + screenShotPath).Build());
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Info;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                case TestStatus.Passed:
                    logstatus = Status.Pass;
                    time = DateTime.Now;
                    fileName = "Screenshot_" + _test.Test.FullName + "_" + time.ToString("dd_MM_yyyy") + "_" + time.ToString("h_mm_ss") + ".png";
                    screenShotPath = Capture(_driver, fileName, logstatus);
                    _test.Log(Status.Pass, "Pass");
                    _test.Log(Status.Pass, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    break;
                case TestStatus.Warning: 
                    logstatus = Status.Warning; 
                    break;
                default:
                    logstatus = Status.Info;
                    break;
            }
            //DeleteOldScreenshots(Directory.GetCurrentDirectory());
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace + message);
            _extent.Flush();
            _driver.Quit();
        }
        protected IWebDriver GetDriver()
        {
            return _driver;
        }
        private static string Capture(IWebDriver driver, String screenShotName, Status logStatus)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().Location;
            var actualPath = pth[..pth.LastIndexOf("bin")];
            string reportPath = new Uri(actualPath).LocalPath;
            var finalpth="";
            switch (logStatus) 
            {
                case Status.Fail:
                    Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots\\" + "Failed");
                    finalpth = string.Concat(pth.AsSpan(0, pth.LastIndexOf("bin")), "Reports\\Screenshots\\", screenShotName);
                    DeleteOldScreenshots(reportPath + "Reports\\" + "Screenshots\\" + "Failed"); 
                    break;
                case Status.Pass:
                    Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots\\" + "Passed");
                    finalpth = string.Concat(pth.AsSpan(0, pth.LastIndexOf("bin")), "Reports\\Screenshots\\Passed\\", screenShotName);
                    DeleteOldScreenshots(reportPath + "Reports\\" + "Screenshots\\" + "Passed"); 
                    break;
                default:
                    break;
            }
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath);

            
            return localpath;
        }

        private static void DeleteOldScreenshots(string reportPath)
        {
            string screenshotFolder = Path.Combine(reportPath);
            

            if (Directory.Exists(screenshotFolder))
            {
                // Get all files in the screenshot folder
                string[] screenshotFiles = Directory.GetFiles(screenshotFolder);

                // Iterate through the files and delete older ones.
                foreach (string file in screenshotFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    DateTime lastWriteTime = fileInfo.LastWriteTime;

                    if (lastWriteTime < DateTime.Now.AddDays(-7))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            // Handle any deletion errors (e.g., permission issues)
                            Console.WriteLine($"Error deleting {file}: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
