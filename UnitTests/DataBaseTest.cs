using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BostDB;

namespace UnitTests
{
    [TestClass]
    public class DataBaseTest
    { 
        [TestMethod]
        public void TestDataBase()
        {        
            DataBase db1 = new DataBase("DataBase1", "Bost", "password");        
            Assert.IsNotNull(db1);
        }

        [TestMethod]
        public void TestDropTable()
        {
            DataBase db2 = new DataBase("DataBase2", "Bost", "password");
            Table table1 = new Table("Table1");
            db2.RemoveTable(table1);
            Assert.IsNull(db2.SearchTableByName("Table1"));

        }
       
        [TestMethod]
        public void TestAddTable()
        {
            DataBase db3 = new DataBase("DataBase3", "Bost", "password");
            Table table2 = new Table("Table2");
            db3.AddTable(table2);
            Assert.AreEqual(table2 , db3.SearchTableByName("Table2"));

        }

        
        [TestMethod]
        public void TestSeachTableByName()
        {
            DataBase db4 = new DataBase("DataBase4", "Bost", "password");
            Table table3 = new Table("Table3");
            db4.AddTable(table3);
            Assert.AreEqual(table3, db4.SearchTableByName("Table3"));

        }

        [TestMethod]
        public void TestSave()
        {
            DataBase db5 = new DataBase("DataBase5", "Bost", "password");
            Table t5 = new Table("Table5");
            Table t6 = new Table("Table6");
            Column c5 = new Column("Column5");
            Column c6 = new Column("Column6");
            c5.AddValue("bat");
            c5.AddValue("otter");
            c6.AddValue("waterfall");
            c6.AddValue("badger");
            t5.AddColumn(c5);
            t5.AddColumn(c6);
            t6.AddColumn(c6);

            db5.AddTable(t5);

            db5.Save("dbTest.txt");

            DataBase db6 = new DataBase("DataBase6", "Bost", "password");
            db6.Load("dbTest.txt");

            Assert.AreEqual("DataBase5", db6.GetName());
            Assert.AreEqual(2, db6.GetNumTables());


        }

        [TestMethod]
        public void TestLoad()
        {
            

        }
    }
}