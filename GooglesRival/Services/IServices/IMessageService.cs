// <copyright file="IMessageService.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Services
{
    using System.Collections.Generic;
    using GooglesRival.Models;

    public interface IMessageService
    {
        Message GetMessageById(string id);

        List<Message> GetMessagesForUser(string username);
    }
}