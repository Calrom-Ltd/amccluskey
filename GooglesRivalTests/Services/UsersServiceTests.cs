using Microsoft.VisualStudio.TestTools.UnitTesting;
using GooglesRival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooglesRival.Controllers;

namespace GooglesRival.Services.Tests
{
    [TestClass()]
    public class UsersServiceTests
    {
        [TestMethod()]
        public void GetAllUsersTest()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut  = service.GetAllUsers();

            ////Assert
            Assert.IsNotNull(sut);
            Assert.AreNotEqual(0, sut.Count);
        }

        [TestMethod()]
        public void VerifyCorrectUsernameAndPassword()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.VerifyUsernameAndPassword("PapaJeff","HanzoMain");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        [TestMethod()]
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

        [TestMethod()]
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

        [TestMethod()]
        public void VerifyAddingANewUser()
        {
            //// Setup
            var service = new UsersService();

            //// Act
            var sut = service.AddNewUser("DonaldTrump", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        [TestMethod()]
        public void VerifyAddingANewUserFailsWhenUserAlreadyExists()
        {
            //// Setup
            IDataSource dataSource = new SQLDataSource();
            var service = new UsersService(dataSource);

            //// Act
            var sut = service.AddNewUser("PapaJeff", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        [TestMethod()]
        public void VerifyCorrectUsernameAndPasswordAfterAddingNewUser()
        {
            //// Setup
            var service = new UsersService();
            service.AddNewUser("NewUser", "Password");

            //// Act
            var sut = service.VerifyUsernameAndPassword("NewUser", "Password");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        [TestMethod()]
        public void VerifyCorrectUsernameAndIncorrectPasswordAfterAddingNewUser()
        {
            //// Setup
            var service = new UsersService();
            service.AddNewUser("NewUser", "Password");

            //// Act
            var sut = service.VerifyUsernameAndPassword("NewUser", "HanzoMain");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }


        [TestMethod()]
        public void VerifyChangePasswordWhenOldPasswordIsCorrect()
        {
            //// Setup
            var service = new UsersService();

            //// Act
            var sut = service.ChangePassword("PapaJeff", "HanzoMain", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut);
        }

        [TestMethod()]
        public void VerifyChangePasswordFailsWhenOldPasswordIsIncorrect()
        {
            //// Setup
            var service = new UsersService();

            //// Act
            var sut = service.ChangePassword("PapaJeff", "nope", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }

        [TestMethod()]
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