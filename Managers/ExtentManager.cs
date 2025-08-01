using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using SeleniumAutomationProjectWithNUnit.Utilities;

namespace SeleniumAutomationProjectWithNUnit.Managers
{
    public static class ExtentManager
    {
        private static ExtentReports _extent;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                string reportPath = Path.Combine(PathUtility.GetBasePath(), "Reports", "ExtentReport.html");
                var htmlReporter = new ExtentSparkReporter(reportPath);

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                _extent.AddSystemInfo("Host Name", "LocalHost");
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("UserName", "TestUser");
            }

            return _extent;
        }
    }
}
