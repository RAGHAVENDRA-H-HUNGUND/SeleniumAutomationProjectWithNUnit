using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationProjectWithNUnit.Utilities
{
    public class ScreenshotCleanup
    {
        public static void DeleteOldScreenshots(string screenshotDirectory)
        {
            try
            {
                if (Directory.Exists(screenshotDirectory))
                {
                    // Get the current date and time
                    DateTime now = DateTime.Now;

                    // Calculate the date 7 days ago
                    DateTime cutoffDate = now.AddDays(-7);

                    // Get all files in the directory
                    FileInfo[] files = new DirectoryInfo(screenshotDirectory).GetFiles();

                    // Iterate through the files and delete those older than 7 days
                    foreach (FileInfo file in files)
                    {
                        // Check if the file is older than the cutoff date
                        if (file.LastWriteTime < cutoffDate)
                        {
                            try
                            {
                                // Delete the file
                                file.Delete();
                            }
                            catch (Exception e)
                            {
                                // Handle deletion errors
                                Console.WriteLine($"Error deleting file {file.FullName}: {e.Message}");
                            }
                        }
                    }
                }
                else
                {
                    // Handle the case where the screenshot directory does not exist
                    Console.WriteLine($"Screenshot directory not found: {screenshotDirectory}");
                }
            }
            catch (Exception e)
            {
                // Handle general exceptions
                Console.WriteLine($"Error during screenshot cleanup: {e.Message}");
            }
        }
    }
}
