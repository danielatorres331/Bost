using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class SelectColumns : IQuery
    {
        private string m_table;
        private string [] m_columnNames;
        public string Table()
        {
            return m_table;
        }
        public string[] ColumnNames()
        {
            return m_columnNames; 
        }

        public SelectColumns(string table,string[] columnNames)
        {
            m_table = table;
            m_columnNames = columnNames;
        }
        public string Run(DataBase database) 
        {
            return null;
        }
    }
}
