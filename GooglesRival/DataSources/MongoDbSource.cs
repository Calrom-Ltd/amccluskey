// <copyright file="MongoDbSource.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.DataSources
{
    using System;
    using System.Collections.Generic;
    using GooglesRival.Controllers;
    using GooglesRival.Models;
    using MongoDB.Driver;

    /// <summary>
    /// Mongo Db Source.
    /// </summary>
    public class MongoDbSource : IDataSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbSource"/> class.
        /// </summary>
        public MongoDbSource()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var dbList = client.ListDatabases().ToList();
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
        public bool AddUser(string username, string password)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// The Object.
        /// </returns>
        /// <exception cref="NotImplementedException">Exception.</exception>
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
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
        public bool UpdateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
