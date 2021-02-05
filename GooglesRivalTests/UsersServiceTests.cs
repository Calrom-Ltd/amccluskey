using Microsoft.VisualStudio.TestTools.UnitTesting;
using GooglesRival.Services;

namespace GooglesRivalTests
{
    [TestClass]
    class UsersServiceTests
    {
        /// <summary>
        /// Verifies the messages exist.
        /// </summary>
        [TestMethod]
        public void VerifyUserExists()
        {
            var message = new MessageService();
            Assert.IsNotNull(message.messages);
            Assert.AreEqual(16, message.messages.Count, "The message count should match");
        }

        /// <summary>
        /// Verifies the message expected is returned.
        /// </summary>
        [TestMethod]
        public void VerifyMessageExpectedIsReturned()
        {
            var message = new MessageService();

            var sut = message.GetMessageById("1");

            Assert.IsNotNull(sut);
            Assert.AreEqual(1, sut.Id, "The returned message should have the same ID");
        }
    }
}
