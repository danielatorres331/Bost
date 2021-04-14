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
            IQuery query = Parser.Parse("SELECT * FROM Table1;");
            Assert.AreEqual("Table1", (query as SelectAll).Table());
        }

       [TestMethod]
        public void TestInsert()
        {
            IQuery query = Parser.Parse("INSERT INTO Table VALUES (34567);");
            Assert.IsTrue(query is Insert);
            Assert.AreEqual("Table", (query as Insert).Table());
            Assert.AreEqual("34567", (query as Insert).Values()[0]);

            IQuery query1 = Parser.Parse("INSERT INTO Table1 VALUES (hi,12,bye);");
            Assert.IsTrue(query1 is Insert);
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
        public void TestUpdate(){
            IQuery query = (Update)Parser.Parse("UPDATE Table1 SET column1=Alfred#Schmidt,column2=Frankfurt WHERE column2=5,column2=4;");
            IQuery query2 = (Update)Parser.Parse("UPDATE Table2 SET column1=Alfred#Schmidt WHERE column2=5;");
            
            Assert.IsTrue(query is Update);
            Assert.IsTrue(query2 is Update);
            
            Assert.AreEqual("Table1", (query as Update).GetTable());
            Assert.AreEqual("Table2", (query2 as Update).GetTable());

            List<string> columns = new List<string>();
            columns.Add("column1");
            columns.Add("column2");
            List<string> columnsParse = (query as Update).GetColumns();
            Assert.AreEqual(columns.Count, columnsParse.Count);
            for(int i = 0; i < columns.Count; i++)
                Assert.AreEqual(columns[i], columnsParse[i]);
            columnsParse = (query2 as Update).GetColumns();
            Assert.AreEqual(1, columnsParse.Count);
            Assert.AreEqual("column1", columnsParse[0]);

            List<string> newValues = new List<string>();
            newValues.Add("Alfred Schmidt");
            newValues.Add("Frankfurt");
            List<string> newValuesParse = (query as Update).GetNewValues();
            Assert.AreEqual(newValues.Count, newValuesParse.Count);
            for (int i = 0; i < newValues.Count; i++)
                Assert.AreEqual(newValues[i], newValuesParse[i]);
            newValuesParse = (query2 as Update).GetNewValues();
            Assert.AreEqual(1, newValuesParse.Count);
            Assert.AreEqual("Alfred Schmidt", newValuesParse[0]);

            List<string> columnsName = new List<string>();
            columnsName.Add("column2");
            columnsName.Add("column2");
            List<string> columnsNameParse = (query as Update).GetColumnsName();
            Assert.AreEqual(columnsName.Count, columnsNameParse.Count);
            for (int i = 0; i < columnsName.Count; i++)
                Assert.AreEqual(columnsName[i], columnsNameParse[i]);
            columnsNameParse = (query2 as Update).GetColumnsName();
            Assert.AreEqual(1, columnsNameParse.Count);
            Assert.AreEqual("column2", columnsNameParse[0]);

            List<string> valuesToUpdate = new List<string>();
            valuesToUpdate.Add("5");
            valuesToUpdate.Add("4");
            List<string> valuesToUpdateParse = (query as Update).GetValuesToUpdate();
            Assert.AreEqual(valuesToUpdate.Count, valuesToUpdateParse.Count);
            for (int i = 0; i < valuesToUpdate.Count; i++)
                Assert.AreEqual(valuesToUpdate[i], valuesToUpdateParse[i]);
            valuesToUpdateParse = (query2 as Update).GetValuesToUpdate();
            Assert.AreEqual(1, valuesToUpdateParse.Count);
            Assert.AreEqual("5", valuesToUpdateParse[0]);
        }

        [TestMethod]
        public void TestDropTable()
        {
            IQuery query = Parser.Parse("DROP TABLE tableName;");
            Assert.IsTrue(query is DropTable);
            //Assert.IsNull((query as DropTable).Table());
        }
    }
}
