﻿using System;
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
        public string GetUser() 
        {
            return m_user;
        }

        public string Run(DataBase database)
        {
            if (database.CanDo("", ""))
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
            else
                return Messages.SecurityNotSufficientPrivileges;
        }
    }
}

