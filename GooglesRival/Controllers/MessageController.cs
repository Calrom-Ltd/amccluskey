// <copyright file="MessageController.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Controllers
{
    using System.Collections.Generic;
    using GooglesRival.Models;
    using GooglesRival.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Message Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        /// <summary>
        /// The message service.
        /// </summary>
        private readonly IMessageService messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController" /> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        /// <summary>
        /// Gets the messages for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The Object.</returns>
        [HttpGet]
        [Route("GetMessagesForUser")]
        public IEnumerable<Message> GetMessagesForUser(string username)
        {
            return this.messageService.GetMessagesForUser(username);
        }

        /// <summary>
        /// Gets the single message.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Object.</returns>
        [HttpGet]
        [Route("GetMessageById")]
        public ActionResult<Message> GetSingleMessage(string id)
        {
            return this.Ok(this.messageService.GetMessageById(id));
        }

        /// <summary>
        /// Gets the single message.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Object.</returns>
        [HttpGet]
        [Route("GetMessages")]
        public ActionResult<Message> GetMessages()
        {
            return this.Ok(this.messageService.GetAllMessages());
        }
    }
}
