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
            if (database.CanDo("DELETE", m_table))
            {
                Table t = database.SearchTableByName(m_table);

                if (t == null)
                {
                    return Messages.TableDoesNotExist;
                }
                else
                {

                    Column c = t.SearchColumnByName(m_column);

                    if (c == null)
                    {
                        return Messages.ColumnDoesNotExist;
                    }
                    else
                    {
                        List<int> index = t.SelectCondition(m_column, m_operator, m_value);
                        List<Column> columns = t.GetColumns();
                        foreach (int i in index)
                        {
                            foreach (Column column in columns)
                                column.DeleteValue(i);
                        }
                        return Messages.TupleDeleteSuccess;
                    }

                }
            }
            else
                return Messages.SecurityNotSufficientPrivileges;
        }
    }
}
