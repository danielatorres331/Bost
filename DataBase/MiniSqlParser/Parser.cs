using Bost.MiniSqlParser;
using BostDB.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BostDB.MiniSqlParser
{
   public class Parser
    {
        public static IQuery Parse(string miniSqlSentence)
        {
            const string selectAllPattern = @"SELECT \* FROM ([a-zA-Z0-9]+)(;| WHERE ([a-zA-Z0-9.]+)([<>=]{1,2})([a-zA-Z0-9.]+);)";
            const string selectColumnsPattern = @"SELECT (([a-zA-Z0-9]+)((,[a-zA-Z0-9]+){0,})) FROM ([a-zA-Z0-9]+)(;| WHERE ([a-zA-Z0-9.]+)([<>=]{1,2})(([a-zA-Z0-9.]+)|'([a-zA-Z0-9.]+)');)";
            const string deletePattern = @"DELETE FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z0-9.]+)([<>=]{1,2})([a-zA-Z0-9.]+);";
            const string insertPattern = @"INSERT INTO ([a-zA-Z0-9]+) VALUES \(([^\)]+)\);";
            const string updatePattern = @"UPDATE ([a-zA-Z0-9]+) SET ([^\s]+) WHERE ([^\s]+);";
            const string dropTablePattern = @"DROP TABLE ([a-zA-Z0-9]+);";
            const string createTablePattern = @"CREATE TABLE (([a-zA-Z0-9]+)) (\((([^\s]+) (TEXT|INT|DOUBLE),?)+\));";
            const string createDataBasePattern = @"([a-zA-Z0-9]+),([a-zA-Z0-9]+),([a-zA-Z0-9]+)";
            const string createSecurityProfilePattern = @"CREATE SECURITY PROFILE ([a-zA-Z0-9]+);";
            const string grantSelectPattern = @"GRANT SELECT ON ([a-zA-Z0-9]+) TO ([a-zA-Z0-9]+);";
            const string addUserPattern = @"ADD USER \((([a-zA-Z0-9']+),([a-zA-Z0-9']+),([a-zA-Z0-9']+))\);";
            const string dropSecurityProfilePattern = @"DROP SECURITY PROFILE ([a-zA-Z0-9']+);";

            Match match;

            if (Regex.Match(miniSqlSentence, selectAllPattern).Success)
            {
                match = Regex.Match(miniSqlSentence, selectAllPattern);
                //Gets a collection of groups matched by the regular expression
                SelectAll selectAll;
                if (match.Groups[2].Value == null)
                {
                   selectAll = new SelectAll(match.Groups[1].Value);
                }
                else 
                {
                   selectAll = new SelectAll(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value);
                }               
                return selectAll;
            }
            else if (Regex.Match(miniSqlSentence, selectColumnsPattern).Success)
            {
                match = Regex.Match(miniSqlSentence, selectColumnsPattern);
                string[] columnNames = match.Groups[1].Value.Split(',');

                //Gets a collection of groups matched by the regular expression
                SelectColumns selectColumns = new SelectColumns(match.Groups[5].Value, columnNames.OfType<string>().ToList(), match.Groups[7].Value, match.Groups[8].Value, match.Groups[9].Value);
                return selectColumns;
            }
            else if (Regex.Match(miniSqlSentence, deletePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, deletePattern);
                Delete deleteValue = new Delete(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value);
                return deleteValue;
            }
            else if (Regex.Match(miniSqlSentence, insertPattern).Success)
            {
                match = Regex.Match(miniSqlSentence, insertPattern);
                string[] values = match.Groups[2].Value.Split(',');

                Insert insert = new Insert(match.Groups[1].Value, values.OfType<string>().ToList());
                return insert;
            }
            else if (Regex.Match(miniSqlSentence, updatePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, updatePattern);
                List<string> columns = new List<string>(), //Save columns
                    newValues = new List<string>(), //Save the new value
                    columnsName = new List<string>(), //Save the name of the column 
                    valuesToUpdate = new List<string>(); //Save values where we want to update

                string[] set = match.Groups[2].Value.Split(',', '=');
                for (int i = 0; i < set.Length; i++)
                {
                    columns.Add(set[i]);
                    i++;

                    if (set[i].Contains("#"))
                    {
                        set[i] = set[i].Replace("#", " ");
                    }
                    newValues.Add(set[i]);
                }

                string[] where = match.Groups[3].Value.Split(',', '=');
                for (int i = 0; i < where.Length; i++)
                {
                    columnsName.Add(where[i]);
                    i++;
                    valuesToUpdate.Add(where[i]);
                }

                Update update = new Update(match.Groups[1].Value, columns, newValues, columnsName, valuesToUpdate);
                return update;
            }
            else if (Regex.Match(miniSqlSentence, createTablePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, createTablePattern);
                string tableName = match.Groups[2].Value;

                List<String> columns = new List<String>();

                string[] columnsPattern = match.Groups[3].Value.Split(',');

                for (int i = 0; i < columnsPattern.Length; i++)
                {
                    String column = columnsPattern[i];
                    int index;

                    index = column.IndexOf('(');
                    if (index != -1)
                        column = column.Remove(index, 1);

                    index = column.IndexOf(' ');
                    if (index != -1)
                        column = column.Remove(index);

                    index = column.IndexOf(')');
                    if (index != -1)
                        column = column.Remove(index, 1);

                    columns.Add(column);
                }
                CreateTable createTable = new CreateTable(tableName, columns);
                return createTable;
            }

            else if (Regex.Match(miniSqlSentence, dropTablePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, dropTablePattern);
                DropTable dropTable = new DropTable(match.Groups[1].Value);
                return dropTable; ;
            }
            else if (Regex.Match(miniSqlSentence, createSecurityProfilePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, createSecurityProfilePattern);

                CreateSecurityProfile createSecurityProfile = new CreateSecurityProfile(match.Groups[1].Value);
                return createSecurityProfile;
            }
            else if (Regex.Match(miniSqlSentence, grantSelectPattern).Success)
            {
                match = Regex.Match(miniSqlSentence, grantSelectPattern);

                GrantSelect grantSelect = new GrantSelect(match.Groups[1].Value, match.Groups[2].Value);
                return grantSelect;
            }
            else if (Regex.Match(miniSqlSentence, addUserPattern).Success)
            {
                match = Regex.Match(miniSqlSentence, addUserPattern);

                AddUser addUser = new AddUser(match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value);
                return addUser;
            }
            else if (Regex.Match(miniSqlSentence, createDataBasePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, createDataBasePattern);

                CreateDataBase dataBase = new CreateDataBase(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                return dataBase;
            }
            else if (Regex.Match(miniSqlSentence, dropSecurityProfilePattern).Success)
            {
                match = Regex.Match(miniSqlSentence, dropSecurityProfilePattern);

                DropSecurityProfile dropSecurityProfile = new DropSecurityProfile(match.Groups[1].Value);
                return dropSecurityProfile;
            }
            else
                return null;
        }
    }
}
