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
        private Profile m_profile3;

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
            Assert.IsNull(m_profile3);
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
        [TestMethod]
        public void TestAddPrivilege()
        {
            
            Privilege privilege = new Privilege("CREATE", "student");
            m_profile2.AddPrivilege(privilege);

            Assert.IsNotNull(m_profile2.GetPrivileges());
            Assert.AreEqual(m_profile2.GetPrivileges().Count, 1);

            Privilege privilege2 = new Privilege("DROP", "location");
            Privilege privilege3 = new Privilege("ALTER", "student");
            Privilege privilege4 = new Privilege("CREATE", "project");

            m_profile.AddPrivilege(privilege2);
            m_profile.AddPrivilege(privilege3);
            m_profile.AddPrivilege(privilege4);

            Assert.AreEqual(m_profile.GetPrivilege("DROP","location"),privilege2);
            Assert.IsNotNull(m_profile.GetPrivileges());
            Assert.IsNull(m_profile.GetPrivilege("CREATE", "student"));
            Assert.AreEqual(m_profile.GetPrivileges().Count, 3);
            Assert.IsNull(m_profile3);
        }
        [TestMethod]
        public void TestGetIndexPrivilege()
        {
            Privilege privilege = new Privilege("DROP", "student");
            Privilege privilege2 = new Privilege("ALTER", "location");
            Privilege privilege3 = new Privilege("CREATE", "teachers");

            m_profile.AddPrivilege(privilege2);
            m_profile.AddPrivilege(privilege3);
            m_profile.AddPrivilege(privilege);

            Assert.AreEqual(m_profile.GetIndexPrivilege("DROP", "student"),2);
            Assert.AreEqual(m_profile.GetIndexPrivilege("ALTER", "location"), 0);
            Assert.AreEqual(m_profile.GetIndexPrivilege("CREATE", "teachers"), 1);
        }
        [TestMethod]
        public void TestDeletePrivilegeByIndex()
        {
            Privilege privilege = new Privilege("DROP", "student");
            Privilege privilege2 = new Privilege("ALTER", "location");
            Privilege privilege3 = new Privilege("CREATE", "teachers");
            Privilege privilege4 = new Privilege("CREATE", "employee");
            Privilege privilege5 = new Privilege("DROP", "project");

            m_profile.AddPrivilege(privilege);
            m_profile.AddPrivilege(privilege2);
            m_profile.AddPrivilege(privilege3);         
            m_profile.AddPrivilege(privilege4);
            m_profile.AddPrivilege(privilege5);

            int index0 = m_profile.GetIndexPrivilege("ALTER", "location");

            Assert.AreEqual(index0, 1);

            m_profile.DeletePrivilegeByIndex(0);
            m_profile.DeletePrivilegeByIndex(1);

            int index = m_profile.GetIndexPrivilege("ALTER", "location");
            int index2 = m_profile.GetIndexPrivilege("CREATE", "employee");
         
            Assert.IsNotNull(m_profile.GetPrivilege("ALTER", "location"));
            Assert.AreEqual(index, 0);
            Assert.AreEqual(index2, 1);


        }
    }        
 }

