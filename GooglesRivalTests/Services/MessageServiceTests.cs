using Microsoft.VisualStudio.TestTools.UnitTesting;
using GooglesRival.Services;
using GooglesRival.Models;
using System;

namespace GooglesRivalTests
{
    [TestClass]
    public class MessageServiceTests
    {

        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyMessagesDetailsCorrect()
        {
            //// Setup
            var messageService = new MessageService();
            Message message = new Message()
            {
                Username = "User0",
                Date = DateTime.Now,
                Subject = "Hey Kids, have you heard of Rick rolling?",
                body = "Haha Press F to Pay respects :-P",
            };
            //// Act
            var sut = messageService.GetMessageById("0");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(message.Id, sut.Id);
            Assert.AreEqual(message.Username, sut.Username);
            Assert.AreEqual(message.Subject, sut.Subject);
            Assert.AreEqual(message.body, sut.body);
        }

        /// <summary>
        /// Verifies the message expected is returned.
        /// </summary>
        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyMessageIsReturnedForValidUsername()
        {
            //// Setup
            var messageService = new MessageService();
            Message message = new Message()
            {
                Username = "User0",
                Date = DateTime.Now,
                Subject = "Hey Kids, have you heard of Rick rolling?",
                body = "Haha Press F to Pay respects :-P",
            };
            //// Act
            var sut = messageService.GetMessagesForUser("User0");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(2, sut.Count);
            Assert.AreEqual(message.Id, sut[0].Id);
            Assert.AreEqual(message.Username, sut[0].Username);
            Assert.AreEqual(message.Subject, sut[0].Subject);
            Assert.AreEqual(message.body, sut[0].body);
        }

        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyNoMessageIsReturnedForInValidUsername()
        {
            //// Setup
            var messageService = new MessageService();

            //// Act
            var sut = messageService.GetMessagesForUser("FakeUserName");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyNoMessageIsReturnedForInValidMessageID()
        {
            //// Setup
            var messageService = new MessageService();

            //// Act
            var sut = messageService.GetMessageById("-1");

            //// Assert
            Assert.IsNull(sut);
        }
    }
}
