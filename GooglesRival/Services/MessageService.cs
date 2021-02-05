using GooglesRival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GooglesRival.Services
{
    public static class MessageService
    {
        /// <summary>
        /// The messages
        /// </summary>
        private static List<Message> messages = new List<Message>();


        /// <summary>
        /// Initialises this instance.
        /// </summary>
        public static void initialise()
        {
            int uniqueMessageCount = 0;
            ////Every user gets this one
            for (int i = 0; i< 10;i++)
            {
                Message tempMessage = new Message();
                tempMessage.Id = uniqueMessageCount;
                uniqueMessageCount++;
                tempMessage.Username = $"User{i}";
                tempMessage.Date = DateTime.Now;
                tempMessage.Subject = "Hey Kids, have you heard of Rick rolling?";
                tempMessage.body = "Haha Press F to Pay respects :-P";
                messages.Add(tempMessage);
            }

            ////Every other user gets this one
            for (int i = 0; i < 10; i++)
            {
                Message tempMessage = new Message();
                tempMessage.Id = uniqueMessageCount;
                uniqueMessageCount++;
                tempMessage.Username = $"User{i}";
                tempMessage.Date = DateTime.Now;
                tempMessage.Subject = "Hey Steam?";
                tempMessage.body = "Nobody: ... Fry: Shut up and take my money";
                messages.Add(tempMessage);
                i++;
            }

            ////The Last user gets this one
            Message lastMessage = new Message();
            lastMessage.Id = uniqueMessageCount;
            uniqueMessageCount++;
            lastMessage.Username = $"User10";
            lastMessage.Date = DateTime.Now;
            lastMessage.Subject = "Fed up of memes?";
            lastMessage.body = "...Crickets...";
            messages.Add(lastMessage);
        }

        /// <summary>
        /// Initialises the specified message.
        /// </summary>
        /// <param name="_message">The message.</param>
        public static void initialise(Message _message)
        {
            messages.Add(_message);
        }

        /// <summary>
        /// Initialises the specified messages.
        /// </summary>
        /// <param name="_messages">The messages.</param>
        public static void initialise(List<Message> _messages)
        {
            foreach (var _message in _messages)
            {
                messages.Add(_message);
            }
        }

        /// <summary>
        /// Gets the messages for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static List<Message> GetMessagesForUser(string username)
        {
            return messages.Where(msg => msg.Username.Equals(username)).ToList();
        }

        /// <summary>
        /// Gets the message by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Message GetMessageById(string id)
        {
            int MessageId = int.Parse(id);
            return messages.Single(msg => msg.Id.Equals(MessageId));
        }
    }
}
