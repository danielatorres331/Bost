using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
   public static class Parser
    {
        public static IQuery Parse(string miniSqlSentence)
        {
           const string selectAllPattern = @"SELECT \* FROM([a-zA-Z0-9]+)";

           Match match = Regex.Match(miniSqlSentence, selectAllPattern);


            return null;
        }
    }
}
