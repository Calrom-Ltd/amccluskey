using GooglesRival.Models;
using GooglesRival.Services;
using GooglesRival.Services.Iservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GooglesRival.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<MessageController> _logger;

        /// <summary>
        /// The message service
        /// </summary>
        private readonly IMessageService messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public MessageController(ILogger<MessageController> logger, IMessageService messageService)
        {
            _logger = logger;
            this.messageService = messageService;
        }

        /// <summary>
        /// Gets the messages for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMessagesForUser")]
        public IEnumerable<Message> GetMessagesForUser(string username)
        {
            return messageService.GetMessagesForUser(username);
        }

        /// <summary>
        /// Gets the single message.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMessageById")]
        public ActionResult<Message> GetSingleMessage(string id)
        {
            return Ok(messageService.GetMessageById(id));
        }
    }
}
