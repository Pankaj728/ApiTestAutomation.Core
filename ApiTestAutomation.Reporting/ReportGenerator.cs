using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ApiTestAutomation.Reporting
{
    class ReportGenerator
    {
        private ExtentReports extent;
        private ExtentTest test;

        public ReportGenerator(string reportPath)
        {
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        public void LogTestStep(Status status, string message)
        {
            test.Log(status, message);
        }

        public void FlushReport()
        {
            extent.Flush();
        }
    }
}