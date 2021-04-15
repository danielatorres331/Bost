using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class SelectAll : IQuery
    {
        private string m_table;
        private string m_column;
        private string m_operator;
        private string m_value;

        public string Table()
        {
            return m_table;
        }

        public  SelectAll(string table)
        {
            m_table = table;
            
        }

        public SelectAll(string table, string column, string operador, string value)
        {
            m_table = table;
            m_column = column;
            m_operator = operador;
            m_value = value;

        }

        public string Run(DataBase database)
        {
            Table table = database.SearchTableByName(m_table);
            if (table != null)
            {
                return table.SelectAll().ToString();
            }
            else
            {
                return Messages.TableDoesNotExist;
            }
                
            Column c = table.SearchColumnByName(m_column);

            if (c != null)
            {
                    List<int> index = table.SelectCondition(m_column, m_operator, m_value);
                    List<Column> columns = table.GetColumns();
                    
                /*foreach (int i in index)
                {
                   
                }*/
            }
            else
            {

            }
        }

    
    }
}
