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
            table2.AddColumn(column2);
            table2.DeleteColumn(column2);
            Assert.IsNull(table2.SearchColumnByName("Column2"));
        }
        
        [TestMethod]
        public void TestGetColumn()
        {

        }
        [TestMethod]
        public void TestAddRow()
        {
        }
        [TestMethod]
        public void TestGetTable()
        {
        }
        
    }
}
