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
        public string Table()
        {
            return m_table;
        }

        public  SelectAll(string table)
        {
            m_table = table;
            
        }
        public string Run(Table table)
        {
            return table.SelectAll(m_table).ToString();
            //return null;
          
        }
    }
}
