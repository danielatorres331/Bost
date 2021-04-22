using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BostDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ProfileTest
    {
        private Profile m_profile;
        private Profile m_profile2;

        public ProfileTest()
        {
            m_profile = new Profile("user");
            m_profile2 = new Profile("admin");
        }

        [TestMethod]
        public void TestProfile()
        {
            Assert.IsNotNull(m_profile);
            Assert.IsNotNull(m_profile2);
        }

        [TestMethod]
        public void TestGetName()
        {
            Assert.AreEqual("user", m_profile.GetName());
            Assert.AreEqual("admin", m_profile2.GetName());
        }

        [TestMethod]
        public void GetPrivileges()
        {
            Assert.IsNull(m_profile.GetPrivileges().FirstOrDefault());
            Assert.IsNull(m_profile2.GetPrivileges().FirstOrDefault());

            List<Privilege> privileges = new List<Privilege>();

            Privilege priv = new Privilege("CREATE", "employee");

            m_profile.AddPrivilege(priv);
            privileges.Add(priv);

            priv = new Privilege("DROP", "project");

            m_profile.AddPrivilege(priv);
            privileges.Add(priv);

            Assert.AreEqual(privileges.Count, m_profile.GetPrivileges().Count);

            for (int i = 0; i < privileges.Count; i++)
            {
                Assert.AreEqual(privileges[i].GetPrivilege(), m_profile.GetPrivileges()[i].GetPrivilege());
                Assert.AreEqual(privileges[i].GetTable(), m_profile.GetPrivileges()[i].GetTable());
            }

            privileges.Clear();
            priv = new Privilege("UPDATE", "location");

            m_profile2.AddPrivilege(priv);
            privileges.Add(priv);

            Assert.AreEqual(privileges.Count, m_profile2.GetPrivileges().Count);

            for (int i = 0; i < privileges.Count; i++)
            {
                Assert.AreEqual(privileges[i].GetPrivilege(), m_profile2.GetPrivileges()[i].GetPrivilege());
                Assert.AreEqual(privileges[i].GetTable(), m_profile2.GetPrivileges()[i].GetTable());
            }
        }

        [TestMethod]
        public void GetPrivilege()
        {
            Assert.IsNull(m_profile.GetPrivileges().FirstOrDefault());
            Assert.IsNull(m_profile2.GetPrivileges().FirstOrDefault());

            List<Privilege> privileges = new List<Privilege>();

            Privilege priv = new Privilege("CREATE", "employee");

            m_profile.AddPrivilege(priv);
            privileges.Add(priv);

            priv = new Privilege("DROP", "project");

            m_profile.AddPrivilege(priv);
            privileges.Add(priv);

            Assert.AreEqual(privileges.Count, m_profile.GetPrivileges().Count);

            for (int i = 0; i < privileges.Count; i++)
            {
                Privilege privilege = privileges[i];
                Privilege privilege2 = m_profile.GetPrivilege(privilege.GetPrivilege(), privilege.GetTable());
                Assert.AreEqual(privilege.GetPrivilege(), privilege2.GetPrivilege());
                Assert.AreEqual(privilege.GetTable(), privilege2.GetTable());
            }

            privileges.Clear();
            priv = new Privilege("UPDATE", "location");

            m_profile2.AddPrivilege(priv);
            privileges.Add(priv);

            Assert.AreEqual(privileges.Count, m_profile2.GetPrivileges().Count);

            for (int i = 0; i < privileges.Count; i++)
            {
                Privilege privilege = privileges[i];
                Privilege privilege2 = m_profile2.GetPrivilege(privilege.GetPrivilege(), privilege.GetTable());
                Assert.AreEqual(privilege.GetPrivilege(), privilege2.GetPrivilege());
                Assert.AreEqual(privilege.GetTable(), privilege2.GetTable());
            }
        }
    }
}
