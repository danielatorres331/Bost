using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BostDB;
using System.Collections.Generic;

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
            Assert.AreEqual(column1, table2.SearchColumnByName("Column1"));

        }

        [TestMethod]
        public void TestDeleteColumn()
        {
            Table table3 = new Table("Table3");
            Column column2 = new Column("Column2");
            table3.AddColumn(column2);
            table3.DeleteColumn("Column2");
            Assert.IsNull(table3.SearchColumnByName("Column2"));
        }
        
        [TestMethod]
        public void TestGetColumn()
        {
            Table table4 = new Table("Table4");
            Column column3 = new Column("Column3");
            table4.AddColumn(column3);
            Assert.Equals("Column3", table4.GetColumn(0));

        }

        [TestMethod]
        public void TestAddRow()
        {
            List<String> values = new List<string>();
            values.Add("value1");
            values.Add("value2");
            Table tableRow = new Table("TableRow");
            Column columnRow1 = new Column("ColumnRow");
            Column columnRow2 = new Column("ColumnRow");
            tableRow.AddColumn(columnRow1);
            tableRow.AddColumn(columnRow2);
            tableRow.AddRow(values);
            int index = columnRow1.GetIndex("value1");
            Assert.AreEqual("value1", columnRow1.GetValue(index));
        }

        [TestMethod]
        public void TestGetName()
        {
            Table table6 = new Table("Table6");
            Assert.Equals("Table6", table6.GetName());

         }

        [TestMethod]
        public void TestSearchColumnByName()
        {
            Table table7 = new Table("Table7");
            Column column4 = new Column("Column4");
            table7.AddColumn(column4);
            Assert.AreEqual(column4, table7.SearchColumnByName("Column4"));

        }
        
    }
}
