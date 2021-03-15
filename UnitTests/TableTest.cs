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
            Column column2 = new Column("Column2");
            table2.AddColumn(column1);
            table2.AddColumn(column2);
            Assert.AreEqual(column1, table2.SearchColumnByName("Column1"));
            Assert.AreEqual(column2, table2.SearchColumnByName("Column2"));

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
            Column column4 = new Column("Column4");
            table4.AddColumn(column3);
            table4.AddColumn(column4);
            Assert.AreEqual(column3, table4.GetColumn(0));
            Assert.AreEqual(column4, table4.GetColumn(1));

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
            columnRow1.AddValue("value3");
            int index = columnRow1.GetIndex("value1");
            Assert.AreEqual("value1", columnRow1.GetValue(index));

        }

        [TestMethod]
        public void TestGetName()
        {
            Table table6 = new Table("Table6");
            Assert.AreEqual("Table6", table6.GetName());

         }

        [TestMethod]
        public void TestSearchColumnByName()
        {
            Table table7 = new Table("Table7");
            Column column4 = new Column("Column4");
            table7.AddColumn(column4);
            Assert.AreEqual(column4, table7.SearchColumnByName("Column4"));

        }
        [TestMethod]
        public void TestGetNumColumns()
        {
            Table table8 = new Table("Table8");
            Column column1 = new Column("Column1");
            Column column2 = new Column("Column2");
            table8.AddColumn(column1);
            table8.AddColumn(column2);
            Assert.AreEqual(2, table8.GetNumColumns());


            Table table9 = new Table("Table9");
            Column column3 = new Column("Column3");
            Column column4 = new Column("Column4");
            Column column5 = new Column("Column5");
            table9.AddColumn(column3);
            table9.AddColumn(column4);
            table9.AddColumn(column5);
            Assert.AreEqual(3, table9.GetNumColumns());

            Table table10 = new Table("Table10");
            Assert.AreEqual(0, table10.GetNumColumns());
        }

        [TestMethod]
        public void TestGetColumns()
        {
            Table t = new Table("Fruits");
            Column fc = new Column("FirstColumn");
            Column sc = new Column("SecondColumn");
            fc.AddValue("Banana");
            sc.AddValue("Peach");
            t.AddColumn(fc);
            t.AddColumn(sc);

            List<Column> columnsTable = new List<Column>();
            columnsTable = t.GetColumns();

            Assert.IsTrue(columnsTable.Contains(fc));
            Assert.IsTrue(columnsTable.Contains(sc));

            Assert.AreEqual(2, columnsTable.Count);



        }

        [TestMethod]
        public void TestSelect()
        {
            Table table10 = new Table("TableName");
            Column c1 = new Column("c1");
            Column c2 = new Column("c2");
            table10.AddColumn(c1);
            table10.AddColumn(c2);

            List<Column> columns = new List<Column>();
            columns = table10.GetColumns();

            List<Column> columns2 = new List<Column>();
            columns2.Add(c1);
            Assert.AreEqual(table10.GetNumColumns(),table10.Select(columns).GetNumColumns());
            Assert.AreEqual(table10.GetColumn(0), table10.Select(columns2).GetColumn(0));

        }

        [TestMethod]
        public void TestSelectAll()
        {
            Table table11 = new Table("TableName");
            Column c11 = new Column("c11");
            Column c22 = new Column("c22");
            table11.AddColumn(c11);
            table11.AddColumn(c22);

            
        }

    }
}
