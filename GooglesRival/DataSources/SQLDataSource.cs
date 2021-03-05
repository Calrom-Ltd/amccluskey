// <copyright file="SqlDataSource.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using GooglesRival.Models;

    /// <summary>
    /// SQL Data Source.
    /// </summary>
    /// <seealso cref="GooglesRival.Controllers.IDataSource" />
    public class SqlDataSource : IDataSource
    {
        private readonly string server = "localhost\\SQLEXPRESS";
        private readonly string database = "MyAPI";
        private readonly SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataSource"/> class.
        /// </summary>
        /// <exception cref="Exception">Unable to connect to Database. Error: " + e.Message.</exception>
        public SqlDataSource()
        {
            string connectionString;
            if (Environment.GetEnvironmentVariable("ConnectionString") == null)
            {
                connectionString = "SERVER=" + this.server + ";" + "DATABASE=" + this.database;
                connectionString += ";Integrated Security=true;";
            }
            else
            {
                connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            }

            try
            {
                this.connection = new SqlConnection(connectionString);
                this.connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(Environment.GetEnvironmentVariable("ConnectionString"));
                Console.WriteLine($"Unable to connect to Database. Connection String: {connectionString + Environment.NewLine + Environment.NewLine} Error: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The Object.</returns>
        public List<User> GetUsers()
        {
            string query = "SELECT * FROM MyAPI_Users";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            var output = new List<User>();
            while (reader.Read())
            {
                output.Add(new User()
                {
                    Username = reader.GetString("MyAPI_Users_Username"),
                    Password = reader.GetString("MyAPI_Users_Password"),
                });
            }

            reader.Close();
            return output;
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        public bool UpdateUser(string username, string password)
        {
            SqlCommand command = this.connection.CreateCommand();
            command.CommandText = "UPDATE MyAPI_Users SET MyAPI_Users_Password = @Password WHERE MyAPI_Users_Username = @Username";
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Username", username);
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
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        public bool AddUser(string username, string password)
        {
            SqlCommand command = this.connection.CreateCommand();
            command.CommandText = "INSERT into MyAPI_Users (MyAPI_Users_Username, MyAPI_Users_Password) VALUES " +
                "(@Username, @Password)";
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
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
        /// Gets the Messages.
        /// </summary>
        /// <returns>
        /// The Object.
        /// </returns>
        public List<Message> GetMessages()
        {
            string query = "SELECT * FROM MyAPI_Messages INNER JOIN MyAPI_Users ON MyAPI_Messages.MyAPI_Messages_UserID = MyAPI_Users.MyAPI_Users_ID";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            var output = new List<Message>();
            while (reader.Read())
            {
                output.Add(new Message()
                {
                    Id = reader.GetInt32("MyAPI_Messages_ID"),
                    Username = reader.GetString("MyAPI_Users_Username"),
                    Date = reader.GetDateTime("MyAPI_Messages_Date"),
                    Subject = reader.GetString("MyAPI_Messages_Subject"),
                    Body = reader.GetString("MyAPI_Messages_Body"),
                });
            }

            reader.Close();
            return output;
        }
    }
}
