﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BostDB;
using BostDB.MiniSqlParser;
namespace UnitTests
{
    [TestClass]
    public class MiniSqlTest
    {
        [TestMethod]
        public void Parsing()
        {
            IQuery query = Parser.Parse("SELECT * FROM Table1;");
            Assert.AreEqual("Table1", (query as SelectAll).Table());
        }

        [TestMethod]
        public void TestInsert()
        {
            IQuery query = Parser.Parse("INSERT INTO Table1 VALUES (34567);"); 
            Assert.AreEqual("Table1", (query as SelectColumns).Table());
            Assert.AreEqual("(34567)", (query as Insert).ToString());
        }


       
       /*[TestMethod]
       public void TestDelete()
        {
           IQuery query = Parser.Parse("DELETE FROM Table1 WHERE VALUES = (34567) ");
           Assert.AreEqual("Table1", (query as SelectAll).Table());
           Assert.AreEqual("(34567)", (query as Delete).ToString());

        }*/

        [TestMethod]
        public void TestUpdate()
        { 
        
        
        }

    }
}
