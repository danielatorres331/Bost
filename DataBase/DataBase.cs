using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   public class DataBase
    {
        //List for storing the tables
       List<Table> tables;

        //Constructor
        public DataBase(String name, String userName, String password)
        { 
        }

        //Delete a table
        public void DropTable (Table table) 
        {

        }

        //Adds a table to the DataBase
        public void AddTable(Table table)
        {
            tables.Add (table);
        }

        //Search a table by name
        public Table SearchTableByName(String name)
        {
            return null;
        }
    }
}
