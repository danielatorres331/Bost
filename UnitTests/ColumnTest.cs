using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BostDB;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ColumnTest
    {
        Column ValuesList = new Column("cName");

        public ColumnTest()
        { 
            ValuesList.AddValue("value1");
            ValuesList.AddValue("value2");
            ValuesList.AddValue("value3");
        }

        [TestMethod]
        public void TestColumn()
        {
            Assert.IsNotNull(ValuesList);
        }

        [TestMethod]
        public void TestGetValue()
        {
            string value1 = ValuesList.GetValue(1);
            string value2 =ValuesList.GetValue(2);
            Assert.AreEqual(value1, "value1");
            Assert.AreEqual(value2, "value2");
        }

        [TestMethod]
        public void TestGetName()
        {
            Assert.IsNotNull(ValuesList.GetName());
            Assert.AreEqual("cName", ValuesList.GetName());
        }

        [TestMethod]
        public void TestDeleteValue()
        {
            ValuesList.DeleteValue(2);
            Column c1 = new Column("column1");
            c1.AddValue("value1");
            c1.AddValue("value2");
            Assert.AreEqual(ValuesList, c1);
           
        }

        [TestMethod]
        public void TestSetValue()
        {
            ValuesList.SetValue(2, "newValueName");
            Column c2 = new Column("column1");
            c2.AddValue("value1");
            c2.AddValue("newValueName");
            c2.AddValue("value3");
            Assert.AreEqual(c2, ValuesList);
           // Assert.AreEqual("newValueName", ValuesList.GetValue(2));
        }

        [TestMethod]
        public void TestAddValue()
        {
            ValuesList.AddValue("newValue");
            Assert.AreEqual("newValue", ValuesList.GetValue(4));
        }

        [TestMethod]
        public void TestGetIndex()
        {
            Assert.AreEqual(1, ValuesList.GetIndex("value2"));
        }
    }
}
