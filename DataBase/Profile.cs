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

        public int GetIndexPrivilege(string privilege, string table)
        {
            int i;
            for (i = 0; i < m_privileges.Count; i++)
            {
                if (m_privileges[i].GetPrivilege() == privilege && m_privileges[i].GetTable() == table)
                {
                    break;
                }
                else
                {
                    if (i == m_privileges.Count - 1) //if the last profile is not the profile we are searching returns -1
                    {
                        i = -1;
                        break;
                    }
                }
            }
            return i;
        }

        public void DeletePrivilegeByIndex(int index)
        {
            m_privileges.RemoveAt(index);
        }
    }
}
