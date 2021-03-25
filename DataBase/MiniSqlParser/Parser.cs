using BostDB.MiniSqlParser;
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
            const string deletePattern = @"DELETE FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z0-9.]+)([<>=]{1,2})([a-zA-Z0-9.]+);";
            const string insertPattern = @"INSERT INTO ([a-zA-Z0-9]+) VALUES \(([^\)]+)\);";


            Match match = Regex.Match(miniSqlSentence, selectAllPattern);
            if (match.Success)
            {
                //Gets a collection of groups matched by the regular expression
                SelectAll selectAll = new SelectAll(match.Groups[1].Value);
                return selectAll;
            }

            match = Regex.Match(miniSqlSentence, selectColumnsPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');

                //Gets a collection of groups matched by the regular expression
                SelectColumns selectColumns = new SelectColumns(match.Groups[2].Value, columnNames);
                return selectColumns;
            }
            match= Regex.Match(miniSqlSentence, deletePattern);
            if (match.Success)
            {
                Delete deleteValue = new Delete(match.Groups[1].Value, match.Groups[2].Value,match.Groups[3].Value, match.Groups[4].Value);
                return deleteValue;
            }

            match = Regex.Match(miniSqlSentence, insertPattern);
            if (match.Success)
            {
                string[] values = match.Groups[2].Value.Split(',');
                List<String> listValues = new List<string>();

                foreach (string v in values)
                {
                    listValues.Add(v);
                }

                Insert insert = new Insert(match.Groups[1].Value, listValues);
                return insert;
            }

            return null;
        }
    }
}
