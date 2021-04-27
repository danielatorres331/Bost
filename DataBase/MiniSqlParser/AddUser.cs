using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class AddUser : IQuery
    {
        private string m_user;
        private string m_password;
        private string m_profileName;
        public AddUser(string user, string password, string profileName)
        {
            m_user = user.Replace("'", "");
            m_password = password.Replace("'", "");
            m_profileName = profileName.Replace("'", "");
        }
        public string GetUser()
        {
            return m_user;
        }
        public string GetPassword()
        {
            return m_password;
        }
        public string GetProfileName()
        {
            return m_profileName;
        }
       
        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
            {
                database.AddUser(new User(m_user, m_password, database.GetProfile(m_profileName)));

                return Messages.SecurityUserAdded;
            }
            else
                return Messages.SecurityNotSufficientPrivileges;

        }
    }
}
