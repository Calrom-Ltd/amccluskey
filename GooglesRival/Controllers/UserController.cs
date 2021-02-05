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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Gets the specified username.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult<bool> Get(string Username, string password)
        {
            return Ok(UsersService.VerifyUsernameAndPassword(Username, password));
        }


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DisplayUsers")]
        public List<User> GetAll()
        {
            return UsersService.GetAllUsers();
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="newPasswordConfirmation">The new password confirmation.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ChangePassword")]
        public ActionResult<bool> ChangePassword(string username, string oldPassword, string newPassword, string newPasswordConfirmation)
        {
            if (newPassword != newPasswordConfirmation)
            {
                return StatusCode(500);
            }
            return Ok(UsersService.ChangePassword(username, oldPassword, newPassword));
        }

        [HttpPut]
        [Route("AddNewUser")]
        public ActionResult<bool> AddNewUser(string username, string password)
        {
            return Ok(UsersService.AddNewUser(username, password));
        }
    }
}
