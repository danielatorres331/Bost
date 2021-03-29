using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class Delete : IQuery
    {
        private string m_table;
        private string m_column;
        private string m_operador;
        private string m_value;

        public string Table()
        {
            return m_table;
        }
        public string Column() 
        {
            return m_column;
        }
        public Delete(string table, string column, string operador, string value)
        {
            m_table = table;
            m_column = column;
            m_operador = operador ;
            m_value = value;


        }
        public string Run(BostDB.DataBase database)
        {
            return null;
        }
    }
}
