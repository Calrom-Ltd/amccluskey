using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GooglesRival.Models;
using System.Data;

namespace GooglesRival.Controllers
{
    public class SQLDataSource : IDataSource
    {
        private readonly string server = "localhost\\SQLEXPRESS";
        private readonly string database = "MyAPI";
        public SqlConnection connection;

        public SQLDataSource()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";Integrated Security=true;";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Unable to connect to Database. Error: " + e.Message);
            }
        }

        public List<User> GetUsers()
        {
            string query = "SELECT * FROM MyAPI_Users";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            var output = new List<User>();
            while (reader.Read())
            {
                output.Add(new User()
                {
                    Username = reader.GetString("MyAPI_Users_Username"),
                    Password = reader.GetString("MyAPI_Users_Password")
                });
            }
            reader.Close();
            return output;
        }
    }
}
