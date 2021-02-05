using GooglesRival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GooglesRival.Services
{
    public static class UsersService
    {
        /// <summary>
        /// The users
        /// </summary>
        private static List<User> users = new List<User>();

        /// <summary>
        /// Initalises this instance.
        /// </summary>
        public static void initalise()
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
        /// Initialises the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void initialise(User user)
        {
            users.Add(user);
        }

        /// <summary>
        /// Intialises the specified users.
        /// </summary>
        /// <param name="_users">The users.</param>
        public static void intialise(List<User> _users)
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
        public static List<User> GetAllUsers()
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
        public static bool VerifyUsernameAndPassword(string username, string password)
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
        public static bool ChangePassword(string username, string oldPassword, string newPassword)
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
        private static bool DoesUserExist(string username)
        {
            return (users.Any(x => x.Username == username));
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static bool AddNewUser(string username, string password)
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
