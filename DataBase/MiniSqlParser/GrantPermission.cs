using BostDB;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.MiniSqlParser
{
    public class GrantPermission: IQuery
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
            throw new NotImplementedException();
        }
    }
}
