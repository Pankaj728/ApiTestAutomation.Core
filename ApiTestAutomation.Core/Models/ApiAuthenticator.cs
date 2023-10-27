using ApiTestAutomation.Core.API_Models;
using AventStack.ExtentReports;
using RestSharp;
using System;

namespace ApiTestAutomation.Core.Models
{
    public class ApiAuthenticator
    {
        private static string authToken;

        public static void GetAuthToken(ExtentTest test, Users user = Users.Account_Administrator)
        {
            var client = new RestClient(ApiEndpoints.tokenUrl);
            var request = new RestRequest(ApiEndpoints.tokenEndpoint, Method.Post);
            test.Info($"Token url used for testing - {ApiEndpoints.tokenUrl + ApiEndpoints.tokenEndpoint}");

            request.AddParameter("Username", GetUserName(user));
            request.AddParameter("Password", GetPassword(user));
            request.AddParameter("grant_type", "password");
            request.AddParameter("client_id", "cGGo5977GcvZRd3wAiBWW58Jo5ShEfXX");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
                authToken = jsonResponse.access_token;
                test.Info($"Token generated for User Role - \'{user}\' having Username - \'{GetUserName(user)}\'");
            }
            else
            {
                test.Error($"Failed to retrieve the token for user {user}. Status Code: {response.StatusCode}");
                throw new Exception("Authentication failed: " + response.ErrorMessage);
            }
        }

        public static RestResponse ExecuteRequest(string url, string apiEndpoints, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(apiEndpoints, method);
           
            if (!string.IsNullOrEmpty(authToken))
            {
                request.AddHeader("Authorization", "Bearer " + authToken);
            }

            var response = client.Execute(request);
            return response;
        }

        public static void UpdateToken()
        {
            authToken = authToken + "sdf";
        }

        private static string GetUserName(Users user)
        {
            return AllUsers.users[user.ToString()].UserName;
        }

        private static string GetPassword(Users user)
        {
            return AllUsers.users[user.ToString()].Password;
        }

        public enum Users
        {
            // User roles available
            Account_Administrator,
            Fleet_Manager,
            Warehouse_Manager,
            Reporting_Only,
            Accounts_Payable,
            Company_Administrator,
            Bill_Pay_Reporting_View_Only,
            Fleet_Card_Auditor,
            Account_Administrator_Flyers_Vantage,
            Dealer_Administrator,
            Dealer_User,
            Adminstrator,
            InvalidUser
        }
    }
}
