using Microsoft.VisualStudio.TestTools.UnitTesting;
using GooglesRival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglesRival.Services.Tests
{
    [TestClass()]
    public class UsersServiceTests
    {
        [TestMethod()]
        public void GetAllUsersTest()
        {
            //// Setup
            var service = new UsersService();

            //// Act
            var sut  = service.GetAllUsers();

            ////Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(3, sut.Count);
        }

        [TestMethod()]
        public void VerifyCorrectUsernameAndPassword()
        {
            //// Setup
            var service = new UsersService();

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
            var service = new UsersService();

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
            var service = new UsersService();

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
            var service = new UsersService();

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
            var service = new UsersService();

            //// Act
            var sut = service.ChangePassword("Misingo", "HanzoMain", "Ohnonono");

            ////Assert
            Assert.IsNotNull(sut);
            Assert.IsFalse(sut);
        }
    }
}