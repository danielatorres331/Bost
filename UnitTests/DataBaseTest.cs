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
            DataBase db1 = new DataBase("DataBase1","Bost","contraseña");        
            Assert.IsNotNull(db1);
        }

        [TestMethod]
        public void TestDropTable()
        {
            DataBase db2 = new DataBase("DataBase2", "Bost", "contraseña");
            Table table1 = new Table("Table1");
            db2.DropTable(table1);
            Assert.IsNull(db2.SearchTableByName("Table1"));

        }
       
        [TestMethod]
        public void TestAddTable()
        {
            DataBase db3 = new DataBase("DataBase3", "Bost", "contraseña");
            Table table2 = new Table("Table2");
            Table table3 = new Table("Table3");
            db3.AddTable(table2);
            db3.AddTable(table3);
            Assert.AreEqual(table2 , db3.SearchTableByName("Table2"));
            Assert.AreEqual(table3, db3.SearchTableByName("Table3"));

        }

        [TestMethod]
        public void TestAddUser()
        {
            DataBase db = new DataBase("DataBase3", "Bost", "contraseña");
            Profile p = new Profile("Student");
            User usu = new User("Manolo", "password", p);
            db.AddUser(usu);
            Assert.IsNotNull(db.SearchUserByName("Manolo"));
            Assert.AreEqual(usu, db.SearchUserByName("Manolo"));
           
        }

        [TestMethod]
        public void TestSearchUserByName()
        {
            DataBase db = new DataBase("DataBase3", "Bost", "contraseña");
            Profile p = new Profile("Student");
            User usu = new User("Manolo", "password", p);
            db.AddUser(usu);
            Assert.AreEqual(usu, db.SearchUserByName("Manolo"));
        }

        
        [TestMethod]
        public void TestSeachTableByName()
        {
            DataBase db4 = new DataBase("DataBase4", "Bost", "contraseña");
            Table table3 = new Table("Table3");
            db4.AddTable(table3);
            Assert.AreEqual(table3, db4.SearchTableByName("Table3"));

        }
    }
}