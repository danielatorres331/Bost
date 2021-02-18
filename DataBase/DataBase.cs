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
       List<Table>Tables;
        String Name;
        String UserName;
        String Password;

        //Constructor
        public DataBase(String name, String userName, String password)
        {
            Name = name;
            UserName = userName;
            Password = password;
        }

        //Delete a table
        public void DropTable (Table table) 
        {
            Tables.Remove(table);
        }

        //Adds a table to the DataBase
        public void AddTable(Table table)
        {
            Tables.Add (table);
        }

        //Search a table by name
        public Table SearchTableByName(String name)
        {
            Table tab = null;
            foreach (Table table in Tables)
            {
                if (table.GetName() == name)
                {
                    tab = table;
                    break; 
                }
            }
            return tab;
        }
    }
}
