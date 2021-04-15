using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class Update : IQuery
    {
        private string m_table;
        private List<string> m_columns;
        private List<string> m_newValues;
        private List<string> m_columnsNamesToUpdate;
        private List<string> m_valuesToUpdate;
        public Update(string table, List<string> columns, List<string> newValues, List<string> columnsName, List<string> valuesToUpdate)
        {
            m_table = table;
            m_columns = columns;
            m_newValues = newValues;
            m_columnsNamesToUpdate = columnsName;
            m_valuesToUpdate = valuesToUpdate;
        }

        public string Run(BostDB.DataBase database)
        {
            BostDB.Table table = database.SearchTableByName(m_table);
            List<int> indexes = new List<int>();
            if (table != null)
            {
                //Find the indexes where we want to update
                for (int i = 0; i < m_columnsNamesToUpdate.Count; i++)
                {
                    BostDB.Column column = table.SearchColumnByName(m_columnsNamesToUpdate[i]);
                    indexes = column.GetIndexes(m_valuesToUpdate[i]);
                }

                //find columns where we want to update
                for (int i = 0; i < m_columns.Count; i++)
                {
                    BostDB.Column column = table.SearchColumnByName(m_columns[i]);
                    //Set the new values in the indexes
                    for (int j = 0; j < indexes.Count; j++)
                    {
                        column.SetValue(indexes[j], m_newValues[i]);
                    }
                }

                return Messages.TupleUpdateSuccess;
            }
            else
                return Messages.TableDoesNotExist;
        }

        public string GetTable()
        {
            return m_table;
        }

        public List<string> GetColumns()
        {
            return m_columns;
        }

        public List<string> GetNewValues()
        {
            return m_newValues;
        }
        public List<string> GetColumnsName()
        {
            return m_columnsNamesToUpdate;
        }

        public List<string> GetValuesToUpdate()
        {
            return m_valuesToUpdate;
        }


    }
}
