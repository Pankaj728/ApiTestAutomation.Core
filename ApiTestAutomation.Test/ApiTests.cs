using System.Net;
using ApiTestAutomation.Core.API_Models;
using ApiTestAutomation.Core.Models;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace ApiTestAutomation.Test
{
    [TestFixture]
    public class ApiTests : BaseTestClass
    {
        /// <summary>
        /// This test method retrieves all user role present in the application.
        /// Also verifies the StatusCode and UseRole count.
        /// </summary>
        [Test]
        public void GetUser_VerifyCount_ShouldSucceed()
        {
            // Act
            test.Info("API url used for the test - " + ApiEndpoints.apiooUrl + ApiEndpoints.getUserRoleEndpoint);
            var response = ApiAuthenticator.ExecuteRequest(ApiEndpoints.apiooUrl, ApiEndpoints.getUserRoleEndpoint, Method.Get);
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            
            // Assert
            test.Info("Status Code received in response - " + response.StatusCode);
            AssertionHelpers.AssertStatusCode(HttpStatusCode.OK, response);

            test.Info("User role type received in response - " + jsonResponse.Count);
            AssertionHelpers.AssertPropertyEquals(12, jsonResponse.Count, "Id");
        }

        /// <summary>
        /// This test method verifies StatusCode when invalid token is passed.
        /// </summary>
        [Test]
        public void GetUser_WithInvalidToken_ShouldFail()
        {
            // Act
            ApiAuthenticator.UpdateToken();
            var response = ApiAuthenticator.ExecuteRequest(ApiEndpoints.apiooUrl, ApiEndpoints.getUserRoleEndpoint, Method.Get);

            // Assert
            test.Info("Status Code received in response - " + response.StatusCode);
            AssertionHelpers.AssertStatusCode(HttpStatusCode.Unauthorized, response);
        }
    }
}
