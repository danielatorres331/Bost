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
        public void TestSelect()
        {
            IQuery query = Parser.Parse("SELECT Name,Age FROM MyTable;");
            Assert.AreEqual("MyTable", (query as SelectColumns).GetTable());

            List<string> columns = new List<string>();
            columns.Add("Name");
            columns.Add("Age");
            List<string> cols = (query as SelectColumns).GetColumnNames();
            Assert.AreEqual(cols.Count, columns.Count);
            for (int i = 0; i < cols.Count; i++)
            {
                Assert.AreEqual(cols[i], columns[i]);
            }
            Assert.AreEqual("", (query as SelectColumns).GetColumn());
            Assert.AreEqual("", (query as SelectColumns).GetOperador());
            Assert.AreEqual("", (query as SelectColumns).GetValue());

            query = Parser.Parse("SELECT Name,Age FROM MyTable WHERE Age>18;");
            Assert.AreEqual("MyTable", (query as SelectColumns).GetTable());
            List<string> columns2 = new List<string>();
            columns2.Add("Name");
            columns2.Add("Age");
            List<string> cols2 = (query as SelectColumns).GetColumnNames();
            Assert.AreEqual(cols2.Count, columns2.Count);
            for (int i = 0; i < cols2.Count; i++)
            {
                Assert.AreEqual(cols2[i], columns2[i]);
            }
            Assert.AreEqual("Age", (query as SelectColumns).GetColumn());
            Assert.AreEqual(">", (query as SelectColumns).GetOperador());
            Assert.AreEqual("18", (query as SelectColumns).GetValue());
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
        public void TestUpdate()
        {
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
            for (int i = 0; i < columns.Count; i++)
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
        public void TestCreateTable()
        {
            IQuery query = (CreateTable)Parser.Parse("CREATE TABLE table1 (nombre TEXT);");
            IQuery query2 = (CreateTable)Parser.Parse("CREATE TABLE table2 (edad INT);");
            IQuery query3 = (CreateTable)Parser.Parse("CREATE TABLE table3 (nombre TEXT,edad INT);");

            Assert.IsTrue(query is CreateTable);
            Assert.IsTrue(query2 is CreateTable);
            Assert.IsTrue(query3 is CreateTable);

            Assert.AreEqual("table1", (query as CreateTable).GetTable());
            Assert.AreEqual("table2", (query2 as CreateTable).GetTable());
            Assert.AreEqual("table3", (query3 as CreateTable).GetTable());

            List<string> columns = new List<string>();
            columns.Add("nombre");
            List<string> columnsParse = (query as CreateTable).GetColumns();
            Assert.AreEqual(columns.Count, columnsParse.Count);
            for (int i = 0; i < columns.Count; i++)
                Assert.AreEqual(columns[i], columnsParse[i]);

            List<string> columns2 = new List<string>();
            columns2.Add("edad");
            List<string> columnsParse2 = (query2 as CreateTable).GetColumns();
            Assert.AreEqual(columns2.Count, columnsParse2.Count);
            for (int i = 0; i < columns2.Count; i++)
                Assert.AreEqual(columns2[i], columnsParse2[i]);

            List<string> columns3 = new List<string>();
            columns3.Add("nombre");
            columns3.Add("edad");
            List<string> columnsParse3 = (query3 as CreateTable).GetColumns();
            Assert.AreEqual(columns3.Count, columnsParse3.Count);
            for (int i = 0; i < columns3.Count; i++)
                Assert.AreEqual(columns3[i], columnsParse3[i]);
        }
        [TestMethod]
        public void TestDropTable()
        {
            IQuery query = Parser.Parse("DROP TABLE tableName;");
            Assert.IsTrue(query is DropTable);
            Assert.AreEqual("tableName", (query as DropTable).Table());
        }

        [TestMethod]
        public void TestCreateSecurityProfile()
        {
            IQuery query = Parser.Parse("CREATE SECURITY PROFILE Student;");

            Assert.IsTrue(query is CreateSecurityProfile);

            Assert.AreEqual("Student", (query as CreateSecurityProfile).GetProfile());
        }

        [TestMethod]
        public void TestGrantPermission()
        {
            IQuery query = Parser.Parse("GRANT SELECT ON StudentPublic TO Student;");

            Assert.IsTrue(query is GrantPermission);

            Assert.AreEqual("SELECT", (query as GrantPermission).GetPermission());
            Assert.AreEqual("Student", (query as GrantPermission).GetUser());
            Assert.AreEqual("StudentPublic", (query as GrantPermission).GetTable());
        }

        [TestMethod]
        public void TestAddUser()
        {
            IQuery query = Parser.Parse("ADD USER (Carolina,1711,Student);");

            Assert.IsTrue(query is AddUser);

            Assert.AreEqual("Carolina", (query as AddUser).GetUser());
            Assert.AreEqual("1711", (query as AddUser).GetPassword());
            Assert.AreEqual("Student", (query as AddUser).GetProfileName());
        }
        [TestMethod]
        public void TestRevokePermission()
        {
            IQuery query = Parser.Parse("REVOKE UPDATE ON StudentPublic TO Student;");

            Assert.IsTrue(query is RevokePermission);

            Assert.AreEqual("UPDATE", (query as RevokePermission).GetPermission());
            Assert.AreEqual("Student", (query as RevokePermission).GetUser());
            Assert.AreEqual("StudentPublic", (query as RevokePermission).GetTable());
        }

        [TestMethod]
        public void TestDropSecurityProfile()
        {
            IQuery query = Parser.Parse("DROP SECURITY PROFILE Student;");

            Assert.IsTrue(query is DropSecurityProfile);

            Assert.AreEqual("Student", (query as DropSecurityProfile).Profile());
        }


        [TestMethod]
    
        public void TestDeleteUser()
        {
            IQuery query = Parser.Parse("DELETE USER Carolina;");

            Assert.IsTrue(query is DeleteUser);

            Assert.AreEqual("Carolina", (query as DeleteUser).GetUser());


        }

    }
}
