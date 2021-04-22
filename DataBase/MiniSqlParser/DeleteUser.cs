using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BostDB;
using BostDB.MiniSqlParser;


namespace BostDB.MiniSqlParser
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

            int index = database.GetIndexUser(m_user);

            if (index == -1)
            {
                return Messages.SecurityUserDoesNotExist;
            }
            else
            {

                database.DeleteUser(index);
                return Messages.SecurityUserDeleted;

            }
        }
    }
}

