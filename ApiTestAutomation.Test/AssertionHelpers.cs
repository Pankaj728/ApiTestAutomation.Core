using System.Net;
using NUnit.Framework;
using RestSharp;

namespace ApiTestAutomation.Test
{
    public class AssertionHelpers:BaseTestClass
    {
        public static void AssertStatusCode(HttpStatusCode expectedStatusCode, RestResponse response)
        {
            Assert.AreEqual(expectedStatusCode, response.StatusCode, "Status code assertion failed");
        }

        public static void AssertPropertyNotNull(object propertyValue, string propertyName)
        {
            Assert.NotNull(propertyValue, $"{propertyName} should not be null");
        }

        public static void AssertPropertyEquals<T>(T expectedValue, T actualValue, string propertyName)
        {
            Assert.AreEqual(expectedValue, actualValue, $"{propertyName} assertion failed");
        }
    }
}
