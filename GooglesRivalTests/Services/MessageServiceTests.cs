// <copyright file="MessageServiceTests.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRivalTests
{
    using System;
    using System.Threading.Tasks;
    using GooglesRival.Controllers;
    using GooglesRival.Models;
    using GooglesRival.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Messages Service Tests.
    /// </summary>
    [TestClass]
    public class MessageServiceTests
    {
        /// <summary>
        /// Verifies the messages details correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        [TestCategory("Demo")]
        public async Task VerifyMessagesDetailsCorrectAsync()
        {
            //// Setup
            IDataSource dataSource = new SqlDataSource();
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
            var sut = await messageService.GetMessageById("1");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(message.Id, sut.Id);
            Assert.AreEqual(message.Username, sut.Username);
            Assert.AreEqual(message.Subject, sut.Subject);
            Assert.AreEqual(message.Body, sut.Body);
            Assert.AreEqual(message.Date, sut.Date);
        }

        /// <summary>
        /// Verifies the messages details correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        [TestCategory("Demo")]
        public async Task VerifyMessagesReturnedForInvalidMessageIDAsync()
        {
            //// Setup
            Mock<IDataSource> mDataSource = new Mock<IDataSource>();
            mDataSource.Setup(data => data.GetMessages()).Throws(new Exception("Sequence contains no matching element"));
            var messageService = new MessageService(mDataSource.Object);
            Message message = new Message()
            {
                Id = 99,
                Username = "TobyT",
                Date = DateTime.Parse("01-01-2021"),
            };
            //// Act
            var sut = await messageService.GetMessageById("99");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(message.Id, sut.Id);
            Assert.AreEqual(message.Username, sut.Username);
            Assert.AreNotEqual(string.Empty, sut.Subject);
            Assert.AreNotEqual(string.Empty, sut.Body);
            Assert.AreNotEqual(string.Empty, sut.Date);
        }

        /// <summary>
        /// Verifies the message expected is returned.
        /// </summary>
        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyMessageIsReturnedForValidUsername()
        {
            //// Setup
            IDataSource dataSource = new SqlDataSource();
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
            Assert.AreNotEqual(0, sut.Count);
            Assert.AreEqual(message.Id, sut[0].Id);
            Assert.AreEqual(message.Username, sut[0].Username);
            Assert.AreEqual(message.Subject, sut[0].Subject);
            Assert.AreEqual(message.Body, sut[0].Body);
            Assert.AreEqual(message.Date, sut[0].Date);
        }

        /// <summary>
        /// Verifies the no message is returned for in valid username.
        /// </summary>
        [TestMethod]
        [TestCategory("Demo")]
        public void VerifyNoMessageIsReturnedForInValidUsername()
        {
            //// Setup
            IDataSource dataSource = new SqlDataSource();
            var messageService = new MessageService(dataSource);

            //// Act
            var sut = messageService.GetMessagesForUser("FakeUserName");

            //// Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(0, sut.Count);
        }
    }
}
