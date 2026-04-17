using Moq;
using server.IAccessors;
using server.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ManagerTests
{
    [TestClass]
    public sealed class GetUserTypeTests
    {

        private Mock<IUserAccessor> MockAccessor;
        private UserManager Manager;

        [TestInitialize]
        public void Setup()
        {
            MockAccessor = new Mock<IUserAccessor>();
            Manager = new UserManager(MockAccessor.Object);
        }

        [TestMethod]
        public void GetUserType_ReturnsAdmin()
        {
            MockAccessor.Setup(a => a.Authenticate("adminUser", "password123")).Returns(true);
            MockAccessor.Setup(a => a.GetUserType("adminUser")).Returns("Admin");

            Assert.AreEqual("Admin", Manager.GetUserType("adminUser", "password123"));
        }

        [TestMethod]
        public void GetUserType_ReturnsVoter()
        {
            MockAccessor.Setup(a => a.Authenticate("voterUser", "password123")).Returns(true);
            MockAccessor.Setup(a => a.GetUserType("voterUser")).Returns("Voter");

            Assert.AreEqual("Voter", Manager.GetUserType("voterUser", "password123"));
        }

        [TestMethod]
        public void GetUserType_ReturnsInvalid()
        {
            MockAccessor.Setup(a => a.Authenticate("invalidUser", "wrongPassword")).Returns(false);

            Assert.AreEqual("Invalid user", Manager.GetUserType("invalidUser", "wrongPassword"));
        }
    }
}
