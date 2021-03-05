// <copyright file="MessageService.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using GooglesRival.Controllers;
    using GooglesRival.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Message Service.
    /// </summary>
    /// <seealso cref="GooglesRival.Services.IMessageService" />
    public class MessageService : IMessageService
    {
        /// <summary>
        /// The data source.
        /// </summary>
        private readonly IDataSource dataSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService" /> class.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        public MessageService(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Gets the messages for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The Object.</returns>
        public List<Message> GetMessagesForUser(string username)
        {
            var messagesFromSource = this.dataSource.GetMessages();
            return messagesFromSource.Where(msg => msg.Username.Equals(username)).ToList();
        }

        /// <summary>
        /// Gets the message by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Message Object.</returns>
        public async Task<Message> GetMessageById(string id)
        {
            int messageId = int.Parse(id);
            try
            {
                var output = this.dataSource.GetMessages().Single(msg => msg.Id.Equals(messageId));
                return output;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Sequence contains no matching element"))
                {
                    //// Call to https://jsonplaceholder.typicode.com/posts/1 to get the response from there...
                    string uriToAccess = "https://jsonplaceholder.typicode.com/posts/";
                    uriToAccess += messageId.ToString();
                    string response = await GetFromProxyAsync(new Uri(uriToAccess));
                    return this.ConvertJsonToMessage(response);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets from proxy asynchronous.
        /// </summary>
        /// <param name="uriToAccess">The URI to access.</param>
        /// <returns>
        /// object.
        /// </returns>
        private static async Task<string> GetFromProxyAsync(Uri uriToAccess)
        {
            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriToAccess);
            httpClient.BaseAddress = uriToAccess;
            var response = httpClient.SendAsync(httpRequest);
            var myResult = await response.Result.Content.ReadAsStringAsync().ConfigureAwait(false);
            httpClient.Dispose();
            return myResult;
        }

        /// <summary>
        /// Converts the json to message.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The Parsed json.</returns>
        private Message ConvertJsonToMessage(string input)
        {
            var message = new Message()
            {
                Date = DateTime.Now,
                Username = "TobyT",
            };

            Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);
            string output = string.Empty;
            message.Id = dictionary.TryGetValue("id", out output) ? int.Parse(output) : 0;
            message.Subject = dictionary.TryGetValue("title", out output) ? output : string.Empty;
            message.Body = dictionary.TryGetValue("body", out output) ? output : string.Empty;
            return message;
        }
    }
}
