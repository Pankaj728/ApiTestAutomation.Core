using System.Collections.Generic;

namespace ApiTestAutomation.Core
{
    class UserCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    static class AllUsers
    {
        public static Dictionary<string, UserCredentials> users = new Dictionary<string, UserCredentials>()
        {
            {"Account_Administrator", new UserCredentials{ UserName = "shyam.kishore", Password = "Rsystems@123" }},
            {"InvalidUser", new UserCredentials{ UserName = "Invalid", Password = "Rsystems@123" }},
        };
    }
}
