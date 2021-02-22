using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class TableTest
    {
        [TestMethod]
        public void TestTable()
        {
            Table table1 = new Table("Table1");
            Assert.IsNotNull(table1);

        }

        [TestMethod]
        public void TestAddColumn()
        {
            Table table2 = new Table("Table2");
            Column column1 = new Column("Column1");
            table2.AddColumn(column1);
            Assert.Equals(column1, table2.SearchColumnByName("Column1"));

        }

        [TestMethod]
        public void TestDeleteColumn()
        {
            Table table3 = new Table("Table3");
            Column column2 = new Column("Column2");
            table3.AddColumn(column2);
            table3.DeleteColumn(column2);
            Assert.IsNull(table3.SearchColumnByName("Column2"));
        }
        
        [TestMethod]
        public void TestGetColumn()
        {
            Table table4 = new Table("Table4");
            Column column3 = new Column("Column3");
            table4.AddColumn(column3);
            Assert.Equals("Column3", table4.getColumn(0));

        }

        [TestMethod]
        public void TestAddRow()
        {
          
        }

        [TestMethod]
        public void TestGetTable()
        {
        }

        [TestMethod]
        public void TestSearchColumnByName()
        {
        }
        
    }
}
