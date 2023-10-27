using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestAutomation.Reporting
{
    public class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        private ExtentManager() { }
        public static ExtentReports CreateInstance(string reportPath)
        {
            if (extent == null)
            {
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }

            return extent;
        }
    }
}
