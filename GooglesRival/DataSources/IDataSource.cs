using GooglesRival.Models;
using System.Collections.Generic;

namespace GooglesRival.Controllers
{
    public interface IDataSource
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="theUser">The user.</param>
        /// <returns></returns>
        bool UpdateUser(string username, string password);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="theUser">The user.</param>
        /// <returns></returns>
        bool AddUser(string username, string password);
    }
}