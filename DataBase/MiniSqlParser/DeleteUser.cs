using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BostDB;
using BostDB.MiniSqlParser;


namespace Bost.MiniSqlParser
{
    public class DeleteUser: IQuery

    {
        private string m_user;

        public DeleteUser(string user)
        {
            m_user = user;
        }



        public string Run(User user)
        {
            /*User u = user.GetUser();

            if (u == null)
            {
                return Messages.SecurityUserDoesNotExist;
            }
            else
            {
                u.GetIndex();
                users.RemoveAt();
            */
                return Messages.SecurityUserDeleted;
            

            }

        public string Run(DataBase database)
        {
            throw new NotImplementedException();
        }
    }
}

