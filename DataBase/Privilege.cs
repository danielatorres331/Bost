using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB
{
    public class Privilege
    {
        private string m_privilege;
        private string m_table;

        public Privilege(string privilege, string table)
        {
            m_privilege = privilege;
            m_table = table;
        }

        public string GetPrivilege()
        {
            return m_privilege;
        }

        public string GetTable()
        {
            return m_table;
        }

    }
}
