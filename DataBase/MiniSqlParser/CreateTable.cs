using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class CreateTable : IQuery
    {
        private string m_table;
        private List<String> m_newColumns;

        public CreateTable(string table, List<String> newColumns)
        {
            m_table = table;
            m_newColumns = newColumns;
        }

        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
            {
                database.AddTable(new Table(m_table));
                Table table = database.SearchTableByName(m_table);

                foreach (String column in m_newColumns)
                {
                    table.AddColumn(new Column(column));
                }

                return Messages.CreateTableSuccess;
            }
            else
                return Messages.SecurityNotSufficientPrivileges;
        }

        public string GetTable()
        {
            return m_table;
        }

        public List<string> GetColumns()
        {
            return m_newColumns;
        }
    }
}
