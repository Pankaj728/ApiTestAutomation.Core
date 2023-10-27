using AventStack.ExtentReports;
using NUnit.Framework;

namespace ApiTestAutomation.Test
{
    public class Tests
    {
        private RestClientHelper restClient;
        private ExtentReports extent;
        private ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            string reportPath = @"C:\Automation\Reports\TestReport.html"; // Replace with your desired report path
            extent = ExtentManager.CreateInstance(reportPath);
        }

        [SetUp]
        public void Setup()
        {
            restClient = new RestClientHelper("https://api.example.com"); // Replace with your API base URL
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            extent.Flush();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}