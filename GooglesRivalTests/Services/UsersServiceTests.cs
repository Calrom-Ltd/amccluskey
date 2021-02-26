// <copyright file="UsersServiceTests.cs" company="Adam's Awesome API">
// Copyright (c) Adam's Awesome API. All rights reserved.
// </copyright>

namespace GooglesRival.Services.Tests
{
    using System.Collections.Generic;
    using GooglesRival.Controllers;
    using GooglesRival.Models;
    using GooglesRival.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Users Service Tests.
    /// </summary>
    [TestClass]
    public class UsersServiceTests
    {
        /// <summary>
        /// Gets all users test.
        /// </summary>
        [TestMethod]
        public void GetAllUsersTest()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.GetAllUsers();

            ////Assert
            Assert.IsNotNull(sut);
            Assert.AreNotEqual(0, sut.Count);
        }

        /// <summary>
        /// Verifies the correct username and password.
        /// </summary>
        [TestMethod]
        public void VerifyCorrectUsernameAndPassword()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.VerifyUsernameAndPassword("PapaJeff", "HanzoMain");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        /// <summary>
        /// Verifies the incorrect username.
        /// </summary>
        [TestMethod]
        public void VerifyIncorrectUsername()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.VerifyUsernameAndPassword("Dr.Fake News", "HanzoMain");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        /// <summary>
        /// Verifies the correct username incorrect password.
        /// </summary>
        [TestMethod]
        public void VerifyCorrectUsernameIncorrectPassword()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.VerifyUsernameAndPassword("PapaJeff", "TheWorng");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        /// <summary>
        /// Verifies the adding a new user.
        /// </summary>
        [TestMethod]
        [TestCategory("MockTests")]
        public void VerifyAddingANewUser()
        {
            //// Setup
            Mock<IDataSource> mDataSource = new Mock<IDataSource>();
            Models.User user = new Models.User()
            {
                Username = "foo",
                Password = "bar",
            };
            mDataSource.Setup(data => data.AddUser(user.Username, user.Password)).Returns(true);
            var service = new UsersService(mDataSource.Object);

            //// Act
            var sut = service.AddNewUser(user.Username, user.Password);

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        /// <summary>
        /// Verifies the adding a new user fails when user already exists.
        /// </summary>
        [TestMethod]
        public void VerifyAddingANewUserFailsWhenUserAlreadyExists()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);
            Models.User user = new Models.User()
            {
                Username = "PapaJeff",
                Password = "Ohnonono",
            };

            //// Act
            var sut = service.AddNewUser(user.Username, user.Password);

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        /// <summary>
        /// Verifies the correct username and password after adding new user.
        /// </summary>
        [TestMethod]
        [TestCategory("MockTests")]
        public void VerifyCorrectUsernameAndPasswordAfterAddingNewUser()
        {
            //// Setup
            Mock<IDataSource> mDataSource = new Mock<IDataSource>();
            User user = new User()
            {
                Username = "foo",
                Password = "bar",
            };
            mDataSource.Setup(data => data.AddUser(user.Username, user.Password)).Returns(true);
            var usersList = new List<User>();
            usersList.Add(user);
            mDataSource.Setup(data => data.GetUsers()).Returns(usersList);
            var service = new UsersService(mDataSource.Object);

            //// Act
            service.AddNewUser(user.Username, user.Password);
            var sut = service.VerifyUsernameAndPassword("foo", "bar");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        /// <summary>
        /// Verifies the correct username and incorrect password after adding new user.
        /// </summary>
        [TestMethod]
        [TestCategory("MockTests")]
        public void VerifyCorrectUsernameAndIncorrectPasswordAfterAddingNewUser()
        {
            //// Setup
            Mock<IDataSource> mDataSource = new Mock<IDataSource>();
            User user = new User()
            {
                Username = "NewUser",
                Password = "bar",
            };
            mDataSource.Setup(data => data.AddUser(user.Username, user.Password)).Returns(true);
            var usersList = new List<User>();
            usersList.Add(user);
            mDataSource.Setup(data => data.GetUsers()).Returns(usersList);
            var service = new UsersService(mDataSource.Object);

            //// Act
            _ = service.AddNewUser(user.Username, user.Password);
            var sut = service.VerifyUsernameAndPassword("NewUser", "HanzoMain");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        /// <summary>
        /// Verifies the change password when old password is correct.
        /// </summary>
        [TestMethod]
        [TestCategory("MockTests")]
        public void VerifyChangePasswordWhenOldPasswordIsCorrect()
        {
            //// Setup
            Mock<IDataSource> mDataSource = new Mock<IDataSource>();
            User user = new User()
            {
                Username = "foo",
                Password = "bar",
            };
            User newUser = new User()
            {
                Username = "foo",
                Password = "Ohnonono",
            };
            mDataSource.Setup(data => data.UpdateUser(newUser.Username, newUser.Password)).Returns(true);
            var usersList = new List<User>();
            usersList.Add(user);
            mDataSource.Setup(data => data.GetUsers()).Returns(usersList);
            var service = new UsersService(mDataSource.Object);

            //// Act
            var sut = service.ChangePassword("foo", "bar", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        /// <summary>
        /// Verifies the change password fails when old password is incorrect.
        /// </summary>
        [TestMethod]
        [TestCategory("MockTests")]
        public void VerifyChangePasswordFailsWhenOldPasswordIsIncorrect()
        {
            //// Setup
            Mock<IDataSource> mDataSource = new Mock<IDataSource>();
            User user = new User()
            {
                Username = "foo",
                Password = "bar",
            };
            User newUser = new User()
            {
                Username = "foo",
                Password = "Ohnonono",
            };
            mDataSource.Setup(data => data.UpdateUser(newUser.Username, newUser.Password)).Returns(true);
            var usersList = new List<User>();
            usersList.Add(user);
            mDataSource.Setup(data => data.GetUsers()).Returns(usersList);
            var service = new UsersService(mDataSource.Object);

            //// Act
            var sut = service.ChangePassword("PapaJeff", "nope", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        /// <summary>
        /// Verifies the change password fails when user doesnt exist.
        /// </summary>
        [TestMethod]
        public void VerifyChangePasswordFailsWhenUserDoesntExist()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.ChangePassword("Misingo", "HanzoMain", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }
    }
}