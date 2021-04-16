// <copyright file="UserController.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using GooglesRival.Models;
    using GooglesRival.Services.Iservices;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// User Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    [ExcludeFromCodeCoverage]
    public class UserController : ControllerBase
    {
        private readonly IUsersService usersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="usersService">The users service.</param>
        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        /// <summary>
        /// Gets the specified username.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult<bool> Get([FromBody] User user)
        {
            return this.Ok(this.usersService.VerifyUsernameAndPassword(user.Username, user.Password));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The Object.</returns>
        [HttpGet]
        [Route("DisplayUsers")]
        public List<User> GetAll()
        {
            return this.usersService.GetAllUsers();
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        [HttpPost]
        [Route("ChangePassword")]
        public ActionResult<bool> ChangePassword([FromBody] ChangePassword changePassword)
        {
            if (changePassword.NewPassword != changePassword.NewPasswordConfirmation)
            {
                return this.StatusCode(500);
            }

            return this.Ok(this.usersService.ChangePassword(changePassword.Username, changePassword.OldPassword, changePassword.NewPassword));
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The Object.
        /// </returns>
        [HttpPut]
        [Route("AddNewUser")]
        public ActionResult<bool> AddNewUser([FromBody] User user)
        {
            return this.Ok(this.usersService.AddNewUser(user.Username, user.Password));
        }
    }
}
