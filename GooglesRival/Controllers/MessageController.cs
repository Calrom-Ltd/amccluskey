using GooglesRival.Models;
using GooglesRival.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GooglesRival.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
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
            return MessageService.GetMessagesForUser(username);
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
            return Ok(MessageService.GetMessageById(id));
        }
    }
}
