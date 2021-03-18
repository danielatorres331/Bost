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
    }
}
