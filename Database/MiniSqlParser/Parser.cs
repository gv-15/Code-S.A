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
            const string selectAllPattern = @"SELECT \* FROM ([a-zA-Z0-9]+)\;";
            const string selectColumnsPattern = @"SELECT ([a-zA-Z0-9]+(,[a-zA-Z0-9]+)*) FROM ([a-zA-Z0-9]+)\;";
            const string deleteFromPattern = @"DELETE FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z0-9.]+)([\<+-\>-\=])([a-zA-Z0-9.]+)\;";
            const string selectWherePattern = @"SELECT ([a-zA-Z0-9,]+) FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z]+)([=><])('{0,1})([a-zA-Z0-9-\.\s]+)('{0,1})";
            const string insertIntoPattern = @"INSERT INTO ([a-zA-Z0-9.]+) VALUES \(([\a-zA-Z0-9.,\'\-)]+)\)\;";
            const string dropTablePattern = @"DROP TABLE ([a-zA-Z0-9.]+)\;";
            const string createTablePattern = @"CREATE TABLE ([a-zA-Z0-9 ]+) \(([a-zA-Z0-9, ]+)\)\;";
            const string selectAllWherePattern = @"SELECT \* FROM ([a-zA-Z0-9.]+) WHERE ([a-zA-Z]+)([=><])('{0,1})([a-zA-Z0-9-\.\s]+)('{0,1})";
            const string closePattern = @"CLOSE\;";
            const string updatePattern = @"UPDATE ([a-zA-Z0-9,]+) SET ([a-zA-Z0-9]+=('{0,1})[a-zA-Z0-9\.\s-]+\3(,[a-zA-Z0-9]+=('{0,1})[a-zA-Z0-9\.\s-]+\5)*) WHERE ([a-zA-Z]+)([=><])('{0,1})([a-zA-Z0-9-\.\s]+)('{0,1})\;";
            const string createSecurityProfilePattern = @"CREATE SECURITY PROFILE ([a-zA-Z0-9_]+)\;";
            const string dropSecurityProfilePattern = @"DROP SECURITY PROFILE ([a-zA-Z0-9_]+)\;";
            const string grantPattern = @"GRANT SELECT ON ([a-zA-Z0-9]+) TO ([a-zA-Z0-9]+)\;";
            const string deleteUserPattern = @"DELETE USER ([a-zA-Z0-9]+)\;";
            const string revokePriviligePattern = @"REVOKE ([a-zA-Z0-9]+) ON ([a-zA-Z0-9]+) TO ([a-zA-Z0-9]+)\;";
            const string addUserPattern = @"ADD USER \((['a-zA-Z0-9,'] +)\)\;";

            Match match = Regex.Match(miniSqlSentence, selectAllWherePattern);
            if (match.Success)
            {

                string[] atributo = match.Groups[1].Value.Split(','); 
                string[] columnNames = match.Groups[2].Value.Split(','); 
                string[] izquierdaWhere = match.Groups[3].Value.Split(','); 
                string[] operationCondition = match.Groups[4].Value.Split(','); 
                string[] derechaWhere = match.Groups[5].Value.Split(','); 

                TableColumn tc = new TableColumn(match.Groups[2].Value);
                if (match.Groups[3].Value.Equals("="))
                {
                    Condition condition = new Condition(Condition.Operations.equals, match.Groups[5].Value, match.Groups[2].Value);
                    SelectAllWhere selectAllWhere = new SelectAllWhere(match.Groups[1].Value, condition);
                    return selectAllWhere;
                }
                if (match.Groups[3].Value.Equals(">"))
                {
                    Condition condition2 = new Condition(Condition.Operations.max, match.Groups[5].Value, match.Groups[2].Value);
                    SelectAllWhere selectAllWhere2 = new SelectAllWhere(match.Groups[1].Value, condition2);
                    return selectAllWhere2;
                }
                if (match.Groups[3].Value.Equals("<"))
                {
                    Condition condition3 = new Condition(Condition.Operations.min, match.Groups[5].Value, match.Groups[2].Value);
                    SelectAllWhere selectAllWhere3 = new SelectAllWhere(match.Groups[1].Value, condition3);
                    return selectAllWhere3;
                }
            }

           match = Regex.Match(miniSqlSentence, selectAllPattern);
            if (match.Success)
            {
                SelectAll selectAll = new SelectAll(match.Groups[1].Value);
                return selectAll;
            }

            match = Regex.Match(miniSqlSentence, closePattern);
            if (match.Success)
            {
                Close close = new Close();
                return close;
            }

            match = Regex.Match(miniSqlSentence, selectWherePattern);
            if (match.Success)
            {

                string[] atributo = match.Groups[1].Value.Split(','); //Atributo que quieres mirar
                string[] columnNames = match.Groups[2].Value.Split(','); //Nombre de la tabla
                string[] izquierdaWhere = match.Groups[3].Value.Split(','); //Atributo despues del Where
                string[] operationCondition = match.Groups[4].Value.Split(','); //El igual, > o <
                string[] derechaWhere = match.Groups[6].Value.Split(','); //Parte derecha del where

                TableColumn tc = new TableColumn(match.Groups[3].Value);
                if (match.Groups[4].Value.Equals("="))
                {
                    Condition condition = new Condition(Condition.Operations.equals, match.Groups[6].Value, match.Groups[3].Value);
                    SelectWhere selectWhere = new SelectWhere(match.Groups[2].Value, Utils.ToList(atributo), condition);
                    return selectWhere;
                }
                if (match.Groups[4].Value.Equals(">"))
                {
                    Condition condition2 = new Condition(Condition.Operations.max, match.Groups[6].Value, match.Groups[3].Value);
                    SelectWhere selectWhere2 = new SelectWhere(match.Groups[2].Value, Utils.ToList(atributo), condition2);
                    return selectWhere2;
                }
                if (match.Groups[4].Value.Equals("<"))
                {
                    Condition condition3 = new Condition(Condition.Operations.min, match.Groups[6].Value, match.Groups[3].Value);
                    SelectWhere selectWhere3 = new SelectWhere(match.Groups[2].Value, Utils.ToList(atributo), condition3);
                    return selectWhere3;
                }

            }

            match = Regex.Match(miniSqlSentence, selectColumnsPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');
                SelectColumns selectColumns = new SelectColumns(match.Groups[3].Value, Utils.ToList(columnNames));
                return selectColumns;
            }
            match = Regex.Match(miniSqlSentence, insertIntoPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');

                string[] list = match.Groups[2].Value.Split(',');
                Insert insert = new Insert(match.Groups[1].Value, Utils.ToList(list));
                return insert;
            }


            match = Regex.Match(miniSqlSentence, deleteFromPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(','); //Nombre de la tabla
                string[] atributo = match.Groups[2].Value.Split(','); //Condicion despues del where
                string[] operationCondition = match.Groups[3].Value.Split(','); //El igual, > o <
                string[] parteDerechaCondition = match.Groups[4].Value.Split(','); //La parte de la derecha de la condicion
                TableColumn tc = new TableColumn(match.Groups[2].Value);
                if (match.Groups[3].Value.Equals("="))
                {
                    Condition condition = new Condition(Condition.Operations.equals, match.Groups[4].Value, match.Groups[2].Value);
                    DeleteFrom deleteFrom = new DeleteFrom(match.Groups[1].Value, Utils.ToList(atributo), condition);
                    return deleteFrom;
                }
                if (match.Groups[3].Value.Equals(">"))
                {
                    Condition condition2 = new Condition(Condition.Operations.max, match.Groups[4].Value, match.Groups[2].Value);
                    DeleteFrom deleteFrom2 = new DeleteFrom(match.Groups[1].Value, Utils.ToList(atributo), condition2);
                    return deleteFrom2;
                }
                if (match.Groups[3].Value.Equals("<"))
                {
                    Condition condition3 = new Condition(Condition.Operations.min, match.Groups[4].Value, match.Groups[2].Value);
                    DeleteFrom deleteFrom3 = new DeleteFrom(match.Groups[1].Value, Utils.ToList(atributo), condition3);
                    return deleteFrom3;
                }
            }

            match = Regex.Match(miniSqlSentence, dropTablePattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');
                DropTable dropTable = new DropTable(match.Groups[1].Value);
                return dropTable;
            }
            match = Regex.Match(miniSqlSentence, updatePattern);
            if (match.Success)
            {

                if (match.Groups[7].Value.Equals("="))
                {
                    Condition condition = new Condition(Condition.Operations.equals, match.Groups[9].Value, match.Groups[6].Value);
                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    string set = match.Groups[2].Value.Replace("'", "");
                    string[] setElements = set.Split(',');
                    for (int i = 0; i < setElements.Length; i++)
                    {
                        string[] columnAndValue = setElements[i].Split('=');
                        string column = columnAndValue[0];
                        string value = columnAndValue[1];

                        columns.Add(column);
                        values.Add(value);
                    }
                    Update update = new Update(match.Groups[1].Value, condition, columns, values);
                    return update;
                }
                if (match.Groups[7].Value.Equals(">"))
                {
                    Condition condition = new Condition(Condition.Operations.max, match.Groups[9].Value, match.Groups[6].Value);
                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    string set = match.Groups[2].Value.Replace("'", "");
                    string[] setElements = set.Split(',');
                    for (int i = 0; i < setElements.Length; i++)
                    {
                        string[] columnAndValue = setElements[i].Split('=');
                        string column = columnAndValue[0];
                        string value = columnAndValue[1];

                        columns.Add(column);
                        values.Add(value);
                    }
                    Update update = new Update(match.Groups[1].Value, condition, columns, values);
                    return update;
                }
                if (match.Groups[7].Value.Equals("<"))
                {
                    Condition condition = new Condition(Condition.Operations.min, match.Groups[9].Value, match.Groups[6].Value);
                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    string set = match.Groups[2].Value.Replace("'", "");
                    string[] setElements = set.Split(',');
                    for (int i = 0; i < setElements.Length; i++)
                    {
                        string[] columnAndValue = setElements[i].Split('=');
                        string column = columnAndValue[0];
                        string value = columnAndValue[1];

                        columns.Add(column);
                        values.Add(value);
                    }
                    Update update = new Update(match.Groups[1].Value, condition, columns, values);
                    return update;
                }

            }

            match = Regex.Match(miniSqlSentence, deleteUserPattern);
            if (match.Success)
            {

                string userName = match.Groups[1].Value;

                DeleteUser deleteUser = new DeleteUser(userName);

                
            }
            match = Regex.Match(miniSqlSentence, createSecurityProfilePattern);
            if (match.Success)
            {

                string profile = match.Groups[1].Value;

                CreateSecurityProfile createSecurityProfile = new CreateSecurityProfile(profile);
            }


            match = Regex.Match(miniSqlSentence, dropSecurityProfilePattern);
            if (match.Success)
            {
                string secProfile = match.Groups[1].Value;

                DropSecurityProfile dropSecurityProfile = new DropSecurityProfile(secProfile);
            }

            match = Regex.Match(miniSqlSentence, grantPattern);
            if (match.Success)
            {

                string table = match.Groups[1].Value;
                string secProfile = match.Groups[2].Value;

                Grant grant = new Grant(secProfile, table);

            }

            match = Regex.Match(miniSqlSentence, revokePriviligePattern);
            if (match.Success)
            {



            }
            match = Regex.Match(miniSqlSentence, addUserPattern);
            if (match.Success)
            {



            }
            match = Regex.Match(miniSqlSentence, createTablePattern);
            if (match.Success)
            {
                List<TableColumn> tableColumn = new List<TableColumn>();
                string[] columnNames = match.Groups[1].Value.Split(',');
                string[] tableColumns = match.Groups[2].Value.Split(',');
                foreach (string value in tableColumns)
                {
                    TableColumn tc = new TableColumn(value);
                    tableColumn.Add(tc);

                }

                CreateTable createTable = new CreateTable(match.Groups[1].Value, tableColumn);
                return createTable;
            }
           
            else
            {
                SyntacticError se = new SyntacticError();
                return se;
            }
           
        }
    }

          
     
}