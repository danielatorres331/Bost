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
        private string m_operator;
        private string m_value;

        public string Table()
        {
            return m_table;
        }
        public string Column() 
        {
            return m_column;
        }
        public string Operator()
        {
            return m_operator;
        }
        public string Value()
        {
            return m_value;
        }
        public Delete(string table, string column, string operador, string value)
        {
            m_table = table;
            m_column = column;
            m_operator = operador;
            m_value = value;


        }
       
        public string Run(DataBase database)
        {
            Table t = database.SearchTableByName(m_table);

            if (t == null)
            {
                return "error";
            }
            else
            {
                List<int> index = t.SelectCondition(m_column,m_operator,m_value);
                Column c = t.SearchColumnByName(m_column);
                if (c == null) 
                {
                    return "error";
                }
                else
                {
                foreach (int i in index)
                {
                    c.DeleteValue(i);
                }
                return  "mensage";
                }
               
            }
            
        }
    }
}
