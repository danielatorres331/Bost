using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.MiniSqlParser
{
    public class AddUser : IQuery
    {
        private string m_user;
        private string m_password;
        private string m_profileName;
        public AddUser(string user, string password, string profileName)
        {
            m_user = user;
            m_password = password;
            m_profileName = profileName;
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
            throw new NotImplementedException();
        }
    }
}
