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
        private User m_user; //The login user

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

        //Adds users to the List
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public User SearchUserByName(string userName)
        {
            User usu = null;
            foreach(User u in Users)
            {
                if(u.GetUser() == userName)
                {
                    usu = u;
                }
            }
            return usu;
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
            foreach (Table tab in Tables)
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
        public void SaveUsers()
        {
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

        public void AddProfile(Profile profile)
        {
            m_profiles.Add(profile);
        }

        public int GetIndexProfile(string name)
        {
            int i;
            for(i = 0; i < m_profiles.Count; i++)
            {
                if(m_profiles[i].GetName() == name)
                {
                    break;
                }
                else
                {
                    if(i == m_profiles.Count - 1) //if the last profile is not the profile we are searching returns -1
                    {
                        i = -1;
                        break;
                    }
                }
            }
            return i;
        }

        public void DeleteProfileByIndex(int index)
        {
            m_profiles.RemoveAt(index);
        }

        public int GetIndexUser(String user)
        {
            int i;

            for (i = 0; i < Users.Count; i++)
            {
                if (Users[i].GetUser() == user)
                {
                    break;
                }

                else
                {
                    if (i == Users.Count - 1)
                    {
                        i = -1;
                        break;
                    }
                }
            }
            return i;

        }

        public void DeleteUser(int index)
        {
            Users.RemoveAt(index);

        }

        public void SetUser(User user)
        {
            m_user = user;
        }

        public User GetUser()
        {
            return m_user;
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public bool CanDo(string privilege, string table)
        {
            bool can = false;
            if (m_user.GetUser() == "admin")
            {
                can = true;
            }
            else
            {
                List<Privilege> privileges = m_user.GetProfile().GetPrivileges();
                foreach (Privilege priv in privileges)
                {
                    if (priv.GetPrivilege() == privilege && priv.GetTable() == table)
                    {
                        can = true;
                        break;
                    }
                }
            }
            return can;
        }
    }
}
  
