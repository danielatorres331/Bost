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
                Column c = table.SearchColumnByName(m_column);
                if (c == null)
                {
                    return table.SelectAll().ToString();
                }
                else
                {
                    List<int> index = table.SelectCondition(m_column, m_operator, m_value);
                    List<Column> columns = table.GetColumns();
                    Table t = new Table("newTable");

                    //Create a new table with the same columns
                    foreach (Column column0 in columns)
                    {
                        t.AddColumn(column0);
                    }

                    foreach (int i in index)
                    {
                        List<string> values = new List<string>();
                        //Collect the values of each index
                        foreach (Column column in columns)
                        {
                            values.Add(column.GetValue(i));
                        }
                        //Add the list of values to the new table
                        t.AddRow(values);
                    }
                    return t.ToString();
                }
            }
            else
            {
                return Messages.TableDoesNotExist;
            }
        }
    }
}
