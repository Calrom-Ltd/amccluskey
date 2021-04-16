// <copyright file="ChangePassword.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// User Class.
    /// </summary>
    public class ChangePassword
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets new passwordconfirmation.
        /// </summary>
        /// <value>
        /// The new password confirmation.
        /// </value>
        public string NewPasswordConfirmation { get; set; }

        [BsonId]
        private ObjectId _Id { get; set; }
    }
}
