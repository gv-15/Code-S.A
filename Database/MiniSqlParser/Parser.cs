using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Database.MiniSqlParser
{
    public static class Parser
    {
        public static IQuery Parse(string miniSqlSentence)
        {
            const string selectAllPattern = @"SELECT \* FROM ([a-zA-Z0-9]+)";
            const string selectColumnsPattern = @"SELECT ([a-zA-Z0-9.]+) FROM ([a-zA-Z0-9]+)";

            Match match = Regex.Match(miniSqlSentence, selectAllPattern);
            
            if (match.Success)
            {
                SelectAll selectAll = new SelectAll(match.Groups[1].Value);
                return selectAll;
            }

            match = Regex.Match(miniSqlSentence, selectColumnsPattern);
            if (match.Success)
            {
               // SelectWhere selectWhere = new SelectWhere(match.Groups[1].Value);
               // return selectWhere;
            }
          return null;
        }
    }
}
