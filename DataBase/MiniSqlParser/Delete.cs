using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    class Delete : IQuery
    {
        private string m_table;
        private string m_column;

        public string Table()
        {
            return m_table;
        }
        public string Column() 
        {
            return m_column;
        }
        public Delete(string table, string column)
        {
            m_table = table;
            m_column = column;

        }
        public string Run(DataBase database)
        {
            return null;
        }
    }
}
