using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   public class DataBase
    {
       List<Table> tables;
        public DataBase(string name, string userName, string password)
        { 
        }
        public void DropTable () 
        {

        }
        public DataBase GetDatabase()
        {
            return this;
        }

        public void AddTable(Table table)
        {
            tables.Add (table);
        }

        public void UpdateDatabase()
        { 
        }
        public Table SearchTableByName(String name)
        {
            return null;
        }
    }
}
