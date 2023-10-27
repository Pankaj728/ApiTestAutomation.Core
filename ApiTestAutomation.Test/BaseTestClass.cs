using ApiTestAutomation.Core.Models;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace ApiTestAutomation.Test
{
    [TestFixture]
    public class BaseTestClass
    {
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var reportPath = (@"C:\Users\shraddha.sawant\Documents\");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Info("Test started.");
            ApiAuthenticator.GetAuthToken(test);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : $"Error: {TestContext.CurrentContext.Result.Message}\nStack Trace: {TestContext.CurrentContext.Result.StackTrace}";
            Status logStatus;

            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    logStatus = Status.Fail;
                    test.Log(logStatus, "Test ended with " + logStatus + stackTrace);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    logStatus = Status.Skip;
                    test.Log(logStatus, "Test ended with " + logStatus);
                    break;
                default:
                    logStatus = Status.Pass;
                    test.Log(logStatus, "Test ended with " + logStatus);
                    break;
            }
            extent.Flush();
        }
    }
}
