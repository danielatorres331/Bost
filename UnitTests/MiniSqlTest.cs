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
            IQuery query = Parser.Parse("INSERT INTO Table VALUES (34567);"); 
            Assert.AreEqual("Table", (query as Insert).Table());
            Assert.AreEqual("34567", (query as Insert).Values()[0]);

            IQuery query1 = Parser.Parse("INSERT INTO Table1 VALUES (hi,12,bye);");
            Assert.AreEqual("Table1", (query1 as Insert).Table());
            Assert.AreEqual("hi", (query1 as Insert).Values()[0]);
            Assert.AreEqual("12", (query1 as Insert).Values()[1]);
            Assert.AreEqual("bye", (query1 as Insert).Values()[2]);


        }

        [TestMethod]
       public void TestDelete()
        {
           IQuery query = Parser.Parse("DELETE FROM Table1 WHERE value=34567;");
           Assert.IsTrue(query is Delete);
           Assert.AreEqual("Table1", (query as Delete).Table());
           Assert.AreEqual("value", (query as Delete).Column());
           
        }

        [TestMethod]
        public void TestUpdate()
        { 
        
        
        }

    }
}
