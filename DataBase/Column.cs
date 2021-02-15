using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Column
    {
        //Column name
        public String Name;

        //List of column values 
        public List<String> ValuesList = new List<String>();

        //Constructor
        public Column(String name)
        {

        }

        //Returns the value of the position specified by parameter
        public String GetValue(int index)
        {
            return null;
        }

        /*
        public List<String> GetValues(String value)
        {
            return null;
        }
        */

        //Returns the name of the column
        public String GetName()
        {
            return null;
        }

        //Returns the columns object
        public Column GetColumn()
        {
            return this;
        }

        //Deletes the value of the position passed by parameter
        public void DeleteValue(int index)
        {

        }
        
        //Change the value of the index position to newValue
        public void SetValue(int index, String newValue)
        {

        }

        //Adds a new value to the column
        public void AddValue(String newValue)
        { 
        
        }

        //Returns the index os the column whose value is the one passed by parameter
        public int GetIndex(String value)
        {
        }
    }
}
