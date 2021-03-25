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
        private string[] m_values;
        private string m_column;
        private string m_value;
        private List<string> val;

        public string Table()
        {
            return m_table;
        }

        public string[] values()
        {
            return m_values;
        }
        public Insert(string table, string[] values)
        {
            m_table = table;
            m_values = values;
        }
        public string Run(DataBase dataBase)
        {
            Table table = dataBase.SearchTableByName(m_table);
            Column column = table.SearchColumnByName(m_column);


            foreach (string values in m_values)
            {
                val.Add(values);
            }

            table.AddRow(val);

            string m = "Se ha insertado correctamente";
            return m;
        }
    }
}
