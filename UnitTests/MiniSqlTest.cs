using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("Table1", (query as SelectAll).Table());
        }

        public void TestInsert()
        {
            IQuery query = Parser.Parse("INSERT INTO ");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("Table1", (query as SelectAll).Table());
        }

        public void TestDelete()
        { 
            
        }

        public void TestUpdate()
        {
            IQuery query = Parser.Parse("UPDATE  ");
            Assert.IsTrue(query is SelectAll);
            Assert.AreEqual("Table1", (query as SelectAll).Table());

        }

    }
}
