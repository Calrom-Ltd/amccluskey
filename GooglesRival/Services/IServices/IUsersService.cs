using GooglesRival.Models;
using System.Collections.Generic;

namespace GooglesRival.Services.Iservices
{
    /// <summary>
    /// The IUsersService Interface
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool AddNewUser(string username, string password);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        bool ChangePassword(string username, string oldPassword, string newPassword);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Verifies the username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool VerifyUsernameAndPassword(string username, string password);
    }
}