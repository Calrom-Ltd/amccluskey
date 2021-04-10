// <copyright file="MongoDbSource.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.DataSources
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using GooglesRival.Controllers;
    using GooglesRival.Models;
    using MongoDB.Driver;

    /// <summary>
    /// Mongo Db Source.
    /// </summary>
    public class MongoDbSource : IDataSource
    {
        private readonly IMongoDatabase db;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbSource"/> class.
        /// </summary>
        public MongoDbSource()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            this.db = client.GetDatabase("MyAPI");
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        /// <exception cref="NotImplementedException">Exception.</exception>
        [ExcludeFromCodeCoverage]
        public bool AddUser(string username, string password)
        {
            User newUser = new User()
            {
                Username = username,
                Password = password,
            };
            try
            {
                this.db.GetCollection<User>("MyAPI_Users").InsertOne(newUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the Messages.
        /// </summary>
        /// <returns>
        /// The Object.
        /// </returns>
        /// <exception cref="NotImplementedException">Exception.</exception>
        public List<Message> GetMessages()
        {
            return this.db.GetCollection<Message>("MyAPI_Messages").Find(_ => true).ToList();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// The Object.
        /// </returns>
        public List<User> GetUsers()
        {
            return this.db.GetCollection<User>("MyAPI_Users").Find(_ => true).ToList();
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        /// <exception cref="NotImplementedException">Exception.</exception>
        [ExcludeFromCodeCoverage]
        public bool UpdateUser(string username, string password)
        {
            try
            {
                var collection = this.db.GetCollection<User>("MyAPI_Users");
                var theUser = collection.Find(user => user.Username == username).First();
                theUser.Password = password;
                collection.ReplaceOne(x => x.Username == username, theUser);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
