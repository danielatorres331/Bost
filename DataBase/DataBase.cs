using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DataBase
    {
        //List for storing the tables
        List<Table> Tables = null;
        String Name;
        String UserName;
        String Password;
        string pathString;

        //Constructor
        public DataBase(String name, String userName, String password)
        {
            Name = name;
            UserName = userName;
            Password = password;
            pathString = @"/Folder";
        }

        //Delete a table
        public void DropTable(Table table)
        {
            Tables.Remove(table);
        }

        //Adds a table to the DataBase
        public void AddTable(Table table)
        {
            Tables.Add(table);
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

        public void Load(string filename)
        {
            string text = File.ReadAllText(filename);
            string[] values = text.Split(new char[] { '~' });
        }

        public void Save(string filename)
        {
            foreach(Table tab in Tables)
            {
                string folderName = System.IO.Path.Combine(pathString, tab.GetName());
                CreateFolder(folderName);
                tab.Save(folderName);
            }
            

        }
        public string GetName()
        {
            return Name;
        }
        public int GetNumTable()
        {
            return Tables.Count;
        }

        public void CreateFolder(string folderName)
        {
            if (!System.IO.File.Exists(folderName))
                {
                    System.IO.File.Create(folderName);
                }            
        }
    }
}
  
