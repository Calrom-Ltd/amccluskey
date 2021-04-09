// <copyright file="IMessageService.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Services
{
    using System.Collections.Generic;
    using GooglesRival.Models;

    /// <summary>
    /// Interface IMessageService.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Gets the message by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Object.</returns>
        Message GetMessageById(string id);

        /// <summary>
        /// Gets the messages for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The Object.</returns>
        List<Message> GetMessagesForUser(string username);

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>The Object.</returns>
        List<Message> GetAllMessages();
    }
}