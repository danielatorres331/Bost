using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BostDB;
using BostDB.MiniSqlParser;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class MiniSqlTest
    {
        [TestMethod]
        public void Parsing()
        {
            SelectAll query = (SelectAll) Parser.Parse("SELECT * FROM Table1;");
            Assert.AreEqual("Table1", query.Table());
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
           
        }*/

        [TestMethod]
        public void TestUpdate(){
            IQuery query = (Update)Parser.Parse("UPDATE Table1 SET column1=Alfred#Schmidt,column2=Frankfurt WHERE column2=5;");
            Assert.IsTrue(query is Update);
            Assert.AreEqual("Table1", (query as Update).GetTable());
            List<string> columns = new List<string>();
            columns.Add("column1");
            columns.Add("column2");
            List<string> columnsParse = (query as Update).GetColumns();
            Assert.AreEqual(columns.Count, columnsParse.Count);
            for(int i = 0; i < columns.Count; i++)
                Assert.AreEqual(columns[i], columnsParse[i]);
        }

    }
}
