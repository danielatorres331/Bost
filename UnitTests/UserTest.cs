using BostDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UserTest
    {
        private User _user;
        private User _user2;
        private Profile profile1;
        private Profile profile2;


        public UserTest()
        {
            _user = new User("u1","u1", profile1);
            _user2 = new User("u2","u2", profile2);
        }

        [TestMethod]
        public void TestGetUser()
        {
            Assert.AreEqual("u1", _user.GetUser());
            Assert.AreEqual("u2", _user2.GetUser());
        }

        [TestMethod]
        public void TestUser() {
            Assert.IsNotNull(_user);
            Assert.IsNotNull(_user2);
            }
    }
}
