using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.MiniSqlParser
{
    public class DropSecurityProfile : IQuery
    {
        private string m_profile;

        public string Profile()
        {
            return m_profile;
        }

        public DropSecurityProfile(string profile)
        {
            m_profile = profile;
        }

        public string Run(DataBase database)
        {
            int index = database.GetIndexProfile(m_profile);

            if(index != -1)
            {
                database.DeleteProfileByIndex(index);
                return Messages.SecurityProfileDeleted;
            }
            else
            {
                return Messages.SecurityProfileDoesNotExist;
            }
        }
    }
}
