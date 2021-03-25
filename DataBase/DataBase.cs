using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB
{
    public class DataBase
    {
        //List for storing the tables
        List<Table> Tables = new List<Table>(); // create the list empty
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
            pathString = System.IO.Path.Combine(@"/Folder", name);
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
        //public Table SelectAll(string name) 
       //{
       // return null;
        //}
       // public Table SelectColumns(string table, List<int> columNames)
       // {
           // foreach (Table tab in Tables)
            //{
                //if (tab.GetName() == table && tab.GetColumn().Equals(columNames))
                //{
              //  }
            //}
          //  return null;
        //}

        // Load database : path, file
        public void Load(string nameDB)
        {
            string dbName = System.IO.Path.Combine(@"/Folder", nameDB);
            if (!System.IO.File.Exists(dbName))
            {
                string[] dirs = Directory.GetDirectories(dbName);
                foreach (string dir in dirs)
                {
                    //create Table
                    Table tab = new Table(Path.GetFileNameWithoutExtension(new DirectoryInfo(dir).Name));
                    AddTable(tab);
                    string[] files = Directory.GetFiles(dir);
                    foreach (string file in files)
                    {
                        // create Columns
                        Column col = new Column(Path.GetFileNameWithoutExtension(new FileInfo(file).Name));
                        tab.AddColumn(col);

                        string text = File.ReadAllText(file);
                        string[] values = text.Split(new char[] { '~' });

                        foreach (string value in values)
                        {
                            col.AddValue(value);
                        }

                    }
                }

            }
        }

        public void Save()
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
        // Read and display the data from your file.
        //try
        //{
        //byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
        //    foreach (byte b in readBuffer)
        // {
        //Console.Write(b + " ");
        //}
        //Console.WriteLine();
        //}
        //  catch (System.IO.IOException e) 
        //{
        //Console.WriteLine(e.Message);
   // }
}
}
  
