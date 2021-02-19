using GooglesRival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using GooglesRival.Services.Iservices;
using GooglesRival.Controllers;

namespace GooglesRival.Services
{
    public class UsersService : IUsersService
    {
        /// <summary>
        /// The data source
        /// </summary>
        private readonly IDataSource dataSource;

        public UsersService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        public UsersService(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public UsersService(User user)
        {
            ////TODO
            ////users.Add(user);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="_users">The users.</param>
        public UsersService(List<User> _users)
        {
            ////TODO
            ////foreach (var _user in _users)
            ////{
            ////    users.Add(_user);
            ////}
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return this.dataSource.GetUsers();
        }

        /// <summary>
        /// Verifies the username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// username
        /// or
        /// password
        /// </exception>
        public bool VerifyUsernameAndPassword(string username, string password)
        {
            var users = this.dataSource.GetUsers();
            if (username == null)
                throw new ArgumentNullException(nameof(username));
            else if (password == null)
                throw new ArgumentNullException(nameof(password));
            else if (users.Any(x => x.Username.Contains(username) && x.Password == password))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var users = this.dataSource.GetUsers();
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == oldPassword)
                {
                    return dataSource.UpdateUser(new User()
                    {
                        Username = username,
                        Password = newPassword,
                    });
                }
            }
            return false;
        }

        /// <summary>
        /// Doeses the user exist.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private bool DoesUserExist(string username)
        {
            var users = this.dataSource.GetUsers();
            return (users.Any(x => x.Username == username));
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool AddNewUser(string username, string password)
        {
            if (!DoesUserExist(username))
            {
                return this.dataSource.AddUser(new User()
                {
                    Username = username,
                    Password = password,
                });
            }
            else
                return false;
        }
    }
}
