using GooglesRival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using GooglesRival.Services.Iservices;

namespace GooglesRival.Services
{
    public class UsersService : IUsersService
    {
        /// <summary>
        /// The users
        /// </summary>
        private static List<User> users = new List<User>();


        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        public UsersService()
        {
            //// This constructor adds a few default users to the service
            users.Add(new User()
            {
                Username = "Admin",
                Password = "Password123",
            });
            users.Add(new User()
            {
                Username = "PapaJeff",
                Password = "HanzoMain",
            });
            users.Add(new User()
            {
                Username = "Fortnite",
                Password = "POGGERS",
            });
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public UsersService(User user)
        {
            users.Add(user);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="_users">The users.</param>
        public UsersService(List<User> _users)
        {
            foreach (var _user in _users)
            {
                users.Add(_user);
            }
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            ////The most basic - populate a list of users, and return the result, all have the same password
            return users;
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
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == oldPassword)
                {
                    user.Password = newPassword;
                    return true;
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
                users.Add(new User()
                {
                    Username = username,
                    Password = password,
                });
                return true;
            }
            else
                return false;
        }
    }
}
