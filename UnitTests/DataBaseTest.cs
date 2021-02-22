using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class DataBaseTest
    { 
        [TestMethod]
        public void TestDataBase()
        {        
            DataBase db1 = new DataBase("DataBase1",Bost,contraseña);        
            Assert.IsNotNull(db1);
        }

        [TestMethod]
        public void TestDropTable()
        {
            DataBase db2 = new DataBase("DataBase2", Bost, contraseña);
            Table table1 = new Table("Table1");
            db2.DropTable(table1);
            Assert.IsNull(table1);

        }
       
        [TestMethod]
        public void TestAddTable()
        {
            DataBase db3 = new DataBase("DataBase3", Bost, contraseña);
            Table table2 = new Table("Table2");
            db3.AddTable(table2);
            Assert.Equals(table2 , db.getTableByName("Table2"));

        }

        /*
        [TestMethod]
        public void TestSeachTableByName()
        {
            DataBase db4 = new DataBase("DataBase4", Bost, contraseña);
            Table table3 = new Table("Table3");
            db4.AddTable(table3);
            Assert.Equals(table3, db.getTableByName("Table3"));

        }
    }
