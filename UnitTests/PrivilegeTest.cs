using System;
using BostDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PrivilegeTest
    {
        private Privilege m_privilege;
        private Privilege m_privilege2;

        public PrivilegeTest()
        {
            m_privilege = new Privilege("ALTER", "table1");
            m_privilege2 = new Privilege("DROP", "table2");
        }

        [TestMethod]
        public void TestPrivilege()
        {
            Assert.IsNotNull(m_privilege);
            Assert.IsNotNull(m_privilege2);
        }

        [TestMethod]
        public void TestGetPrivilege()
        {
            Assert.AreEqual("ALTER", m_privilege.GetPrivilege());
            Assert.AreEqual("DROP", m_privilege2.GetPrivilege());
        }

        [TestMethod]
        public void TestGetTable()
        {
            Assert.AreEqual("table1", m_privilege.GetTable());
            Assert.AreEqual("table2", m_privilege2.GetTable());
        }
    }
}
