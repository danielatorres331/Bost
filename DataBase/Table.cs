using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB
{
    public class Table
    {
        //Table name
        public String Name;

        //List of columns in the table
        public List<Column> Columns;

        //Constructor
        public Table(String name)
        {
            Name = name;
            Columns = new List<Column>();
        }

        internal object SelectAll(string m_table)
        {
            throw new NotImplementedException();
        }

        //Adds a column to the table
        public void AddColumn(Column column)
        {
            Columns.Add(column);
        }

        //Deletes a column from the table by name
        public void DeleteColumn(String name)
        {
            Columns.Remove(SearchColumnByName(name));
        }

        //Returns the column whose index is passed by parameter
        public Column GetColumn(int index) 
        {
            return Columns[index];
        }
        public String GetName()
        {
            return Name;
        }
        //Adds the values of the list passed by parameter to the columns of the table
        public void AddRow(List<String> values)
        {
            for(int i=0; i < Columns.Count; i++)
            {
                if(i < values.Count) //If values has more values
                {
                    Columns[i].AddValue(values[i]);
                }
                else //If there are less values than columns
                {
                    Columns[i].AddValue(null);
                }
            }

        }

        //Returns the column whose name is passed by parameter
        public Column SearchColumnByName(String name)
        {
            Column column1 = null;
            foreach(Column column in Columns)
            {
                if(column.GetName() == name)
                {
                    column1 = column;
                    break;
                }
            }
            return column1;
        }
        public int GetNumColumns() {

            return Columns.Count;
           
        }
        public List<Column> GetColumns()        
        {
            return this.Columns;
        }
        public void Save(string folder)
        {
            foreach(Column column in Columns)
            {
                string txtName = column.GetName() + ".txt";
                string pathString = System.IO.Path.Combine(folder, txtName);
                //(path, content)
                File.WriteAllText(pathString, column.Save());
            }
        }
        /**/
        public Table Select(List<Column> columns) 
        {
            Table newTable = new Table("newTable");

            foreach (Column column in columns) 
            {
                newTable.AddColumn(column);            
            }
            return newTable;
        
        }
        public Table SelectAll()
        {
            Table newTable = new Table("newTable");
            List<Column> columnsTable = new List<Column>();
            columnsTable = this.GetColumns();

            foreach (Column column in columnsTable)
            {
                newTable.AddColumn(column);
            }            
            return newTable;
        }
    }
}
