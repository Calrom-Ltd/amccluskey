// <copyright file="IDataSource.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Controllers
{
    using System.Collections.Generic;
    using GooglesRival.Models;

    /// <summary>
    /// IDataSource Interface.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The Object.</returns>
        List<User> GetUsers();

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The Object.</returns>
        bool UpdateUser(string username, string password);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        bool AddUser(string username, string password);

        /// <summary>
        /// Gets the Messages.
        /// </summary>
        /// <returns>The Object.</returns>
        List<Message> GetMessages();
    }
}