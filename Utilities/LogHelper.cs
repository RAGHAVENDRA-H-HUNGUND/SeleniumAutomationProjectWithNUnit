using log4net;
using System.Reflection;

namespace SeleniumAutomationProjectWithNUnit.Utilities
{
    public static class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message) => log.Info(message);
        public static void Debug(string message) => log.Debug(message);
        public static void Warn(string message) => log.Warn(message);
        public static void Error(string message) => log.Error(message);
    }
}
