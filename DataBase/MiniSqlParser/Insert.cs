using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BostDB;

namespace BostDB.MiniSqlParser
{
    public class Insert : IQuery
    {
        private string m_table;
        private List<String> m_values;

        public string Table()
        {
            return m_table;
        }

        public List<String> Values()
        {
            return m_values;
        }

            public Insert( string table, List<String> values)
        {
            m_table = table;
            m_values = values;
        }

        public string Run(DataBase database)
        {
            Table t = database.SearchTableByName(m_table);

            if (t == null)
            {
                return Messages.TableDoesNotExist;
            }
            else
            {
                t.AddRow(m_values);
                return Messages.InsertSuccess;
            }
                  
            
        }
    }
}
