using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Utilities.ReportUtilities
{
    public class ExtentService
    {
        //public static ExtentReports extent;

        //public static ExtentReports Ge5tExtent()
        //{
        //    if (extent == null)
        //    {
        //        extent = new ExtentReports();
        //        string reportDir = Path.Combine(Utility.GetProjectRootDirectory(), "Report");
        //        if (!Directory.Exists(reportDir)) Directory.CreateDirectory(reportDir);

        //        string path = Path.Combine(reportDir, "index.html");
        //        var reporter = new ExtentSparkReporter(path);
        //        reporter.Config.DocumentTitle = "Framework Report";
        //        reporter.Config.ReportName = "Test Automation Report";
        //        reporter.Config.Theme = Theme.Standard;
        //        extent.AttachReporter(reporter);
        //    }
        //    return extent;
        //}
    }
}
