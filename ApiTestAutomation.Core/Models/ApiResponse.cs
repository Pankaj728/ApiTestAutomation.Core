using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestAutomation.Core
{
    public class ApiResponse
    {
        public string Message { get; set; }

        public class UserRoleDetails
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
