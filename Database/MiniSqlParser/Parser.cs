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
            const string deleteFromPattern = @"DELETE FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z0-9.]+) ([\<+-\>-\=]) ([a-zA-Z0-9.]+)";
            const string selectWherePattern = @"SELECT ([a-zA-Z0-9.]+) FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z0-9.]+) ([\<+-\>-\=]) ([a-zA-Z0-9.]+)";
            const string insertIntoPattern = @"INSERT INTO ([a-zA-Z0-9.]+) VALUES \(([a-zA-Z0-9,)]+)\)";
            const string dropTablePattern = @"DROP TABLE ([a-zA-Z0-9.]+)";
            const string createTablePattern = @"CREATE TABLE ([a-zA-Z0-9]+) \(([a-zA-Z0-9,]+)\)";

            Match match = Regex.Match(miniSqlSentence, selectAllPattern);
            
            if (match.Success)
            {
                SelectAll selectAll = new SelectAll(match.Groups[1].Value);
                return selectAll;
            }

            match = Regex.Match(miniSqlSentence, selectColumnsPattern);
            if (match.Success)
            { //Falta mirar hacer el split pero con listas, o cambiar las cosas anteriores a array
                string [] columnNames = match.Groups[1].Value.Split(',');
                SelectColumns selectColumns = new SelectColumns(match.Groups[2].Value, Utils.ToList(columnNames));
                return selectColumns;
            }
            match = Regex.Match(miniSqlSentence, insertIntoPattern);
            if (match.Success)
            { //Falta implementarlo bien, esta puesto lo basico
                string[] columnNames = match.Groups[1].Value.Split(',');
               // Insert insert= new Insert(match.Groups[2].Value, columnNames);
               //return insert;
            }


            match = Regex.Match(miniSqlSentence, deleteFromPattern);
            if (match.Success)
            { //Falta implementarlo bien, esta puesto lo basico
                string[] columnNames = match.Groups[1].Value.Split(',');
                //DeleteFrom deleteFrom = new DeleteFrom(match.Groups[3].Value, columnNames,);
               // return deleteFrom;
            }

            match = Regex.Match(miniSqlSentence, selectWherePattern);
            if (match.Success)
            { //Falta implementarlo bien, esta puesto lo basico
                string[] columnNames = match.Groups[1].Value.Split(',');
                //SelectWhere selectWhere = new SelectWhere(match.Groups[4].Value, columnNames,);
                //return selectWhere;
            }

            match = Regex.Match(miniSqlSentence, dropTablePattern);
            if (match.Success)
            { //Falta implementarlo bien, esta puesto lo basico
                string[] columnNames = match.Groups[1].Value.Split(',');
                //DropTable dropTable = new DropTable(match.Groups[5].Value, columnNames);
                //return dropTable;
            }

            match = Regex.Match(miniSqlSentence, createTablePattern);
            if (match.Success)
            { //Falta implementarlo bien, esta puesto lo basico
                string[] columnNames = match.Groups[1].Value.Split(',');
                //CreateTable createTable = new CreateTable(match.Groups[6].Value, columnNames);
                //return createTable;
            }

            return null;
        }
    }
}
