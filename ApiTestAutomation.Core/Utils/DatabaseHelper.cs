using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using RestSharp;
using Dapper;

namespace ApiTestAutomation.Core
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<T> GetData<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var data = connection.Query<T>(query, parameters).ToList();

                return data;
            }
        }

        public void ExecuteQuery(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute(query, parameters);
            }
        }
    }
}
