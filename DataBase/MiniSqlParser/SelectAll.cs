using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.MiniSqlParser
{
    public class SelectAll : IQuery
    {
        private string m_table;
       
        

        public  SelectAll(string table)
        {
            m_table = table;
            
        }
        public string Run(DataBase database)
        {
          //  return database.SelectAll(m_table).ToString;
          return null;
        }
    }
}
