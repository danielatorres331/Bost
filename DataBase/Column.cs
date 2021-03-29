using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB
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
            Name = name;
        }

        //Returns the value of the position specified by parameter
        public String GetValue(int index)
        {
            return ValuesList[index];
        }

        //Returns the name of the column
        public String GetName()
        {
            return Name;
        }

        //Deletes the value of the position passed by parameter
        public void DeleteValue(int index)
        {
           ValuesList.RemoveAt(index);
        }
        
        //Change the value of the index position to newValue
        public void SetValue(int index, String newValue)
        {
            ValuesList[index] = newValue;
        }

        //Adds a new value to the column
        public void AddValue(String newValue)
        {
            ValuesList.Add(newValue);
        }

        //Returns the index os the column whose value is the one passed by parameter
        public int GetIndex(String value)
        {
            int i;
            for ( i = 0; i< ValuesList.Count; i++)
            {
                if (ValuesList[i] == value) 
                {
                    break;
                }      
            }
            return i;
            int i;
            for ( i = 0; i< ValuesList.Count; i++)
            {
                if (ValuesList[i] == value) 
                {
                    break;
                }      
            }
            return i;
        }

        public string Save() {
            string text = null;
            foreach (string value in ValuesList)
            {
                text = value + "~";
            }

            return text;
        }
        public List<String> GetValues() 
        {
            return ValuesList;
        }
    }
}
