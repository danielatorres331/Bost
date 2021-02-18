using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Table
    {
        //Table name
        public String Name;

        //List of columns in the table
        public List<Column> Columns = new List<Column>();

        //Constructor
        public Table(String name, List<Column> columns)
        {
            Name = name;
            Columns = columns;
        }

        //Adds a column to the table
        public void AddColumn(Column column)
        {
            Columns.Add(column);
        }

        //Deletes a column from the table by name
        public void DeleteColumn(String name)
        {
            Columns.Remove(column);
        }


        //Returns the column whose index is passed by parameter
        public Column GetColumn(int index) 
        {
            return null;
        }

        //Adds the values of the list passed by parameter to the columns of the table
        public void AddRow(List<String> values)
        {
            
        }

        //Returns the column whose name is passed by parameter
        public Column SearchColumnByName(String name)
        {
            return null;
        }
    }
}
