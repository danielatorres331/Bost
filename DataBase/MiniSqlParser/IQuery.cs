using System;
using System.Collections.Generic;
using System.Text;


namespace BostDB.MiniSqlParser
{
   public interface IQuery
    {

        string Run(DataBase database);
    }
}
