using GooglesRival.Models;
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
        private static readonly string[] names = new[]
        {
            "Sneezy", "Sleepy", "Happy", "Doc", "Grumpy", "Dopey", "Other"
        };

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
            if (Username == null || password == null)
                return StatusCode(500);
            else if (names.Contains(Username) && password == "FooBar")
                return Ok(true);
            else
                return Ok(false);
        }


        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DisplayUsers")]
        public List<Users> GetAll()
        {
            ////The most basic - populate a list of users, and return the result, all have the same password
            List<Users> userList = new List<Users>();
            foreach (var name in names)
            {
                Users tempUser = new Users();
                tempUser.Username = name;
                tempUser.Password = "FooBar";
                userList.Add(tempUser);
            }
            return userList;
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
            if (username == null || oldPassword == null || newPassword == null || newPasswordConfirmation == null)
                return StatusCode(500);
            else if (newPassword != newPasswordConfirmation)
                return BadRequest(false);
            else if (oldPassword != "FooBar")
                return Ok(false);
            else if (!names.Contains(username))
                return NotFound(false);
            else if (names.Contains(username) && oldPassword == "FooBar")
                return Ok(true);
            return StatusCode(500);
        }
    }
}
