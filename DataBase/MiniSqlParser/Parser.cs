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
           const string selectColumnsPattern = @"SELECT ([a-zA-Z0-9,]+)FROM([a-zA-Z0-9]+)";
            const string delete = @"DELETE FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z0-9.]+) .{1,3} ([a-zA-Z0-9.]+);";
            Match match = Regex.Match(miniSqlSentence, selectAllPattern);
            if(match.Success)
            {
                //Gets a collection of groups matched by the regular expression
                SelectAll selectAll = new SelectAll(match.Groups[1].Value);
                return selectAll;
            }
            match = Regex.Match(miniSqlSentence,selectColumnsPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split('~');

                //Gets a collection of groups matched by the regular expression
                SelectColumns selectColumns = new SelectColumns(match.Groups[2].Value, columnNames);
                return selectColumns;
            }

            return null;
        }
    }
}
