using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class CreateSecurityProfile : IQuery
    {
        private string m_user;
        public CreateSecurityProfile(string user)
        {
            m_user = user;
        }
        public string GetUser()
        {
            return m_user;
        }
        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
            {
                database.AddProfile(new Profile(m_user));
                return Messages.SecurityProfileCreated;
            }
            else
                return Messages.SecurityNotSufficientPrivileges;
        }
    }
}
