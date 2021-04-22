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

        List<User> Users = new List<User>(); // create the list empty
        private List<Profile> m_profiles; //Create an empty list of profiles



        //Constructor
        public DataBase(String name, String userName, String password)
        {
            Name = name;
            UserName = userName;
            Password = password;
            pathString = System.IO.Path.Combine(@"/Folder", name);
            m_profiles = new List<Profile>();
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

        

        //Save Users
        public void SaveUsers() {
            
            string folderName = System.IO.Path.Combine(pathString);
            CreateFolder(folderName);
          
            foreach (User us in Users)
            {
                File.WriteAllText(pathString, us.Save());
            }
        }

        public List<Profile> GetProfiles()
        {
            return m_profiles;
        }

        public Profile GetProfile(string name)
        {
            Profile prof = null;
            foreach (Profile profile in m_profiles)
            {
                if (profile.GetName() == name)
                {
                    prof = profile;
                    break;
                }
            }
            return prof;
        }

    }
}
  
