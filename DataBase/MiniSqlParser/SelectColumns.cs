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
        private List<string> m_columnNames;
        private string m_column;
        private string m_operador;
        private string m_value;
        public string Table()
        {
            return m_table;
        }
        public List<string> ColumnNames()
        {
            return m_columnNames; 
        }

        public SelectColumns(string table,List<string> columnNames, string column, string operador, string value)
        {
            m_table = table;
            m_columnNames = columnNames;
            m_column = column;
            m_operador = operador;
            m_value = value;
        }
        public string Run(DataBase database) 
        {
            List<Column> columns = new List<Column>();
            
            Table tab = database.SearchTableByName(m_table);
            
            if (tab != null)
            {
                if (m_column != null)
                {
                    List<int> indexes = tab.SelectCondition(m_column, m_operador, m_value);
                    List<Column> cols = tab.GetColumns();
                    Column col;
                    foreach (Column column in cols)
                    {
                        col = new Column(column.GetName());
                        columns.Add(col);
                        foreach(int index in indexes)
                        {
                            col.AddValue(column.GetValue(index));
                        }      
                    }
                }

                foreach (string column in m_columnNames)
                {
                    columns.Add(tab.SearchColumnByName(column));
                    tab = tab.Select(columns);
                }
                
                return tab.ToString();

            }
            else
                return Messages.TableDoesNotExist;
        }
    }
}
