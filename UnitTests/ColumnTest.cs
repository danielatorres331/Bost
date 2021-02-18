using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataBase;


namespace UnitTests
{
    [TestClass]
    public class ColumnTest
    {
        Column c = new Column("cName");

        [TestMethod]
        public void TestColumn()
        {
            Assert.IsNotNull(c1);
            
        }

        [TestMethod]
        public void TestGetValue()
        {
            
        }
        */

        [TestMethod]
        public void TestGetName()
        {
            Assert.IsNotNull(c.getName());
            Assert.AreEqual("cName", c.getName());
        }

        [TestMethod]
        public void TestGetColumn()
        {
        }

        [TestMethod]
        public void TestDeleteValue()
        {
        }

        [TestMethod]
        public void TestSetValue()
        {
        }

        [TestMethod]
        public void TestAddValue()
        {
        }

        [TestMethod]
        public void TestGetIndex()
        {
        }
    }
}
