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
        private string m_profile;
        public CreateSecurityProfile(string profile)
        {
            m_profile = profile;
        }
        public string GetProfile()
        {
            return m_profile;
        }
        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
            {
                database.AddProfile(new Profile(m_profile));
                return Messages.SecurityProfileCreated;
            }
            else
                return Messages.SecurityNotSufficientPrivileges;
        }
    }
}
