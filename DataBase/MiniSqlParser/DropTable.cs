using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BostDB;

namespace BostDB.MiniSqlParser
{
    public class DropTable : IQuery
    {

        private string m_table;
        
        public string Table()
        {
            return m_table;
        }

        public DropTable(string table)
        {
            m_table = table;
        }

        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
            {
                Table t = database.SearchTableByName(m_table);

                if (t == null)
                {
                    return Messages.TableDoesNotExist;
                }
                else
                {
                    database.DropTable(t);
                    return Messages.DeleteTableSuccess;
                }
            }
            else
                return Messages.SecurityNotSufficientPrivileges;
        }
    }
}
