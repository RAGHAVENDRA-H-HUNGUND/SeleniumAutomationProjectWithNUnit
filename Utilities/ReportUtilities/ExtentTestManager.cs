using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Utilities.ReportUtilities
{
    public class ExtentTestManager
    {
        //[ThreadStatic]
        //private static ExtentTest parentTest;

        //[ThreadStatic]
        //private static ExtentTest childTest;

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest CreateParentTest(string testName, string description = null)
        //{
        //    parentTest = ExtentService.Ge5tExtent().CreateTest(testName, description);
        //    return parentTest;
        //}

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest CreateChildTest(string testName, string description = null)
        //{
        //    childTest = parentTest.CreateNode(testName, description);
        //    return childTest;
        //}

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public static ExtentTest GetTest()
        //{
        //    return childTest;
        //}
    }
}
