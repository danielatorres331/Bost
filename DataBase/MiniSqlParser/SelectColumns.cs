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

        public string GetColumn()
        {
            return m_column;
        }

        public string GetOperador()
        {
            return m_operador;
        }
        public string GetValue()
        {
            return m_value;
        }
        public string GetTable()
        {
            return m_table;
        }

        public List<string> GetColumnNames()
        {
            return m_columnNames;
        }

        public string Run(DataBase database) 
        {
            List<Column> columns = new List<Column>();
            Table tab = database.SearchTableByName(m_table);
            List<Column> columns2 = new List<Column>();
            List<string> names;
            Column col;
            if (tab != null)
            {
                List<Column> cols = tab.GetColumns();
                if (m_column != "")
                {
                    names = new List<string>();
                    List<int> indexes = tab.SelectCondition(m_column, m_operador, m_value);

                    foreach (Column column in cols)
                    {
                        col = new Column(column.GetName()); //Create the column
                        names = m_columnNames; //Add the name of the column to a List with names
                        columns.Add(col); //Add column to a List of columns
                        
                        foreach (int index in indexes)
                        {
                            col.AddValue(column.GetValue(index));//Get value of the of the index
                        }
                    }
                }
                else
                {
                    names = m_columnNames;
                    columns = tab.GetColumns();
                }

                Table table = new Table("Table");//Create a new table
                foreach(Column column1 in columns) //Add columns to the table
                {
                    table.AddColumn(column1);
                }
                
                foreach (string column in names) 
                    columns2.Add(table.SearchColumnByName(column));

                table = table.Select(columns2);

                return table.ToString();

            }
            else
                return Messages.TableDoesNotExist;
        }
    }
}
