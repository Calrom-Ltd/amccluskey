// <copyright file="IDataSource.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Controllers
{
    using System.Collections.Generic;
    using GooglesRival.Models;

    public interface IDataSource
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="theUser">The user.</param>
        /// <returns></returns>
        bool UpdateUser(string username, string password);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="theUser">The user.</param>
        /// <returns></returns>
        bool AddUser(string username, string password);

        /// <summary>
        /// Gets the Messages
        /// </summary>
        /// <returns></returns>
        List<Message> GetMessages();
    }
}