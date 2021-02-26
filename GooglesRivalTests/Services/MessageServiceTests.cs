using Microsoft.VisualStudio.TestTools.UnitTesting;
using GooglesRival.Services;
using GooglesRival.Models;
using System;
using GooglesRival.Controllers;

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
            IDataSource dataSource = new SQLDataSource();
            var messageService = new MessageService(dataSource);
            Message message = new Message()
            {
                Id = 1,
                Username = "Admin",
                Date = DateTime.Parse("01-01-2021"),
                Subject = "Test",
                Body = "Testing that this works",
            };
            //// Act
            var sut = messageService.GetMessageById("1");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(message.Id, sut.Id);
            Assert.AreEqual(message.Username, sut.Username);
            Assert.AreEqual(message.Subject, sut.Subject);
            Assert.AreEqual(message.Body, sut.Body);
            Assert.AreEqual(message.Date, sut.Date);
        }

        /// <summary>
        /// Verifies the message expected is returned.
        /// </summary>
        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyMessageIsReturnedForValidUsername()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var messageService = new MessageService(dataSource);
            Message message = new Message()
            {
                Id = 1,
                Username = "Admin",
                Date = DateTime.Parse("01-01-2021"),
                Subject = "Test",
                Body = "Testing that this works",
            };
            //// Act
            var sut = messageService.GetMessagesForUser("Admin");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual(message.Id, sut[0].Id);
            Assert.AreEqual(message.Username, sut[0].Username);
            Assert.AreEqual(message.Subject, sut[0].Subject);
            Assert.AreEqual(message.Body, sut[0].Body);
            Assert.AreEqual(message.Date, sut[0].Date);
        }

        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyNoMessageIsReturnedForInValidUsername()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var messageService = new MessageService(dataSource);

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
            IDataSource dataSource = new SQLDataSource();
            var messageService = new MessageService(dataSource);

            //// Act
            var sut = messageService.GetMessageById("-1");

            //// Assert
            Assert.IsNull(sut);
        }
    }
}
