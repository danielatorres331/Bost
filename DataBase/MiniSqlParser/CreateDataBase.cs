using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.MiniSqlParser
{
    public class CreateDataBase : IQuery
    {
        private string m_name;
        private string m_user;
        private string m_password;
        public CreateDataBase(string name, string user, string password)
        {
            m_name = name;
            m_user = user;
            m_password = password;
        }
        public string GetName()
        {
            return m_name;
        }
        public string GetUser()
        {
            return m_user;
        }
        public string GetPassword()
        {
            return m_password;
        }
        public string Run(DataBase database)
        {
            //if DataBase doesnt exist
            //return Messages.CreateDatabaseSuccess;

            //if DataBase exists
            //return Messages.OpenDatabaseSuccess;

            return null;
        }
    }
}
