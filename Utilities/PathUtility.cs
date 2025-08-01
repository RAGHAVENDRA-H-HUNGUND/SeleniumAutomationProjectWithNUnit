using System.Reflection;

namespace SeleniumAutomationProjectWithNUnit.Utilities
{
    public static class PathUtility
    {
        public static string GetBasePath()
        {
            var path = Assembly.GetCallingAssembly().Location;
            var actualPath = path[..path.LastIndexOf("bin")];
            return new Uri(actualPath).LocalPath;
        }
    }
}
