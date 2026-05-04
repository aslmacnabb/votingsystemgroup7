using Microsoft.VisualStudio.TestTools.UnitTesting;
using server.Managers;

namespace server.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        private UserManager um;

        [TestInitialize]
        public void Setup()
        {
            um = new UserManager();
        }

        [TestMethod]
        public void Authenticate_ValidCredentials_ReturnsTrue()
        {
            bool result = um.Authenticate("Bob", "password");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Authenticate_InvalidCredentials_ReturnsFalse()
        {
            bool result = um.Authenticate("Bob", "wrongpassword");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAccountType_ValidAdmin_ReturnsAdmin()
        {
            string result = um.GetAccountType("HuskersAdmin", "password");
            Assert.AreEqual("admin", result);
        }

        [TestMethod]
        public void GetAccountType_InvalidCredentials_ReturnsError()
        {
            string result = um.GetAccountType("Bob", "wrongpassword");
            Assert.AreEqual("Error: invalid username and password!", result);
        }
    }
}