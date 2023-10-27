using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestAutomation.Core.API_Models
{
    public class ApiEndpoints
    {
        public const string tokenUrl = "https://myportalauthoo.flyersenergy.com";
        public const string alooUrl = "https://myportaloo.flyersenergy.com/";
        public static string apiooUrl = "https://myportalapioo.flyersenergy.com/";
       
        public const string tokenEndpoint = "/oAuth2/token";
        public const string viewUserEndpoint = "/User/ViewUser";
        public const string getUserRoleEndpoint = "api/role";

        public static class Users
        {
            public const string getUser = "/users/{id}";
            public const string createUser = "/users";
            public const string updateUser = "/users/{id}";
            public const string deleteUser = "/users/{id}";
        }
    }
}
