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
            Assert.AreEqual("Table1", (query as SelectAll).Table());
        }

        [TestMethod]
        public void TestInsert()
        {
            IQuery query = Parser.Parse("INSERT INTO Table1 VALUES ((34567));"); 
            Assert.AreEqual("Table1","(34567)", (query as Insert).Table());
        }

       /* [TestMethod]
       public void TestDelete()
        {
           IQuery query = Parser.Parse("DELETE FROM Table1 WHERE VALUES = '34567' ");
           Assert.IsTrue(query is Delete);
           Assert.AreEqual("Table1", "34567", (query as Delete).Table());
           
        }

        [TestMethod]
        public void TestUpdate()
        { 
        
        
        }*/

    }
}
