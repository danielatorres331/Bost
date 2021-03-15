using System;
using System.Collections.Generic;
using System.Text;


namespace DataBase.MiniSqlParser
{
   public interface IQuery
    {
        string Run(DataBase database);
    }
}
