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
        private readonly SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLDataSource"/> class.
        /// </summary>
        /// <exception cref="Exception">Unable to connect to Database. Error: " + e.Message</exception>
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

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="theUser">The user.</param>
        /// <returns></returns>
        public bool UpdateUser(User theUser)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText= "UPDATE MyAPI_Users SET MyAPI_Users_Password = @Password WHERE MyAPI_Users_Username = @Username";
            command.Parameters.AddWithValue("@Password", theUser.Password);
            command.Parameters.AddWithValue("@Username", theUser.Username);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="theUser">The user.</param>
        /// <returns></returns>
        public bool AddUser(User theUser)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT into MyAPI_Users (MyAPI_Users_Username, MyAPI_Users_Password) VALUES " +
                "(@Username, @Password)";
            command.Parameters.AddWithValue("@Username", theUser.Username);
            command.Parameters.AddWithValue("@Password", theUser.Password);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
