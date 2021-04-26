using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
    public class GrantPermission : IQuery
    {
        private string m_permission;
        private string m_user;
        private string m_table;

        public GrantPermission(string permission, string table, string user)
        {
            m_permission = permission;
            m_table = table;
            m_user = user;
        }
        public string GetPermission()
        {
            return m_permission;
        }
        public string GetUser()
        {
            return m_user;
        }
        public string GetTable()
        {
            return m_table;
        }
        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
            {
                Privilege privilege = new Privilege(m_permission, m_table);
                Profile profile = database.GetProfile(m_user);
                if (profile != null)
                {
                    profile.AddPrivilege(privilege);
                    return Messages.SecurityPrivilegeGranted;
                }
                else
                {
                    return Messages.SecurityProfileDoesNotExist;
                }
            }
            else
                return Messages.SecurityNotSufficientPrivileges;
        }
    }
}
