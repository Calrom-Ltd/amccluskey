// <copyright file="UserController.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Controllers
{
    using System.Collections.Generic;
    using GooglesRival.Models;
    using GooglesRival.Services.Iservices;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        /// <summary>
        /// Gets the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult<bool> Get(string username, string password)
        {
            return this.Ok(this.usersService.VerifyUsernameAndPassword(username, password));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DisplayUsers")]
        public List<User> GetAll()
        {
            return this.usersService.GetAllUsers();
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
                return this.StatusCode(500);
            }

            return this.Ok(this.usersService.ChangePassword(username, oldPassword, newPassword));
        }

        [HttpPut]
        [Route("AddNewUser")]
        public ActionResult<bool> AddNewUser(string username, string password)
        {
            return this.Ok(this.usersService.AddNewUser(username, password));
        }
    }
}
