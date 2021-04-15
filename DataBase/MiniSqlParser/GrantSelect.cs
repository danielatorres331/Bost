using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.MiniSqlParser
{
    public class GrantSelect : IQuery
    {
        private string m_permission;
        private string m_user;
        public GrantSelect(string permission, string user)
        {
            m_permission = permission;
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
        public string Run(DataBase database)
        {
            throw new NotImplementedException();
        }
    }
}
