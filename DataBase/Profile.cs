using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB
{
  public class Profile
    {
        private string m_name;
        private List<Privilege> m_privileges;

        public Profile(string name)
        {
            m_name = name;
            m_privileges = new List<Privilege>();
        }

        public string GetName()
        {
            return m_name;
        }

        public List<Privilege> GetPrivileges()
        {
            return m_privileges;
        }

        public Privilege GetPrivilege(string privilegeName, string table)
        {
            Privilege priv = null; 
            foreach(Privilege privilege in m_privileges)
            {
                if(privilege.GetPrivilege() == privilegeName && privilege.GetTable() == table)
                {
                    priv = privilege;
                    break;
                }
            }

            return priv;
        }

        public void AddPrivilege (Privilege privilege)
        {
            m_privileges.Add(privilege);
        }
    }
}
