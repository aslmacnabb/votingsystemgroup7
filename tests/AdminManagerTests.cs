using Microsoft.VisualStudio.TestTools.UnitTesting;
using server.Managers;

namespace server.Tests
{
    [TestClass]
    public class AdminManagerTests
    {
        private AdminManager am;

        [TestInitialize]
        public void Setup()
        {
            am = new AdminManager();
        }

        [TestMethod]
        public void AddElection_ValidCredentials_ReturnsSuccess()
        {
            string result = am.AddElection("HuskersAdmin", "password", "Test Election");
            Assert.AreEqual("Election Test Election successfully added!", result);
        }

        [TestMethod]
        public void AddElection_InvalidCredentials_ReturnsError()
        {
            string result = am.AddElection("HuskersAdmin", "wrongpassword", "Test Election");
            Assert.AreEqual("Error: your username and password are not valid!", result);
        }
    }
}