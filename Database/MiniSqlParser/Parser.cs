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

            match = Regex.Match(miniSqlSentence, selectWherePattern);
            if (match.Success)
            {

                string[] atributo = match.Groups[1].Value.Split(','); //Atributo que quieres mirar
                string[] columnNames = match.Groups[2].Value.Split(','); //Nombre de la tabla
                string[] izquierdaWhere = match.Groups[3].Value.Split(','); //Atributo despues del Where
                string[] operationCondition = match.Groups[4].Value.Split(','); //El igual, > o <
                string[] derechaWhere = match.Groups[5].Value.Split(','); //Parte derecha del where

                TableColumn tc = new TableColumn(match.Groups[3].Value);
                if (match.Groups[4].Value.Equals("="))
                {
                    Condition condition = new Condition(Condition.Operations.equals, match.Groups[5].Value, match.Groups[3].Value);
                    SelectWhere selectWhere = new SelectWhere(match.Groups[2].Value, Utils.ToList(columnNames), condition);
                    return selectWhere;
                }
                if (match.Groups[4].Value.Equals(">"))
                {
                    Condition condition2 = new Condition(Condition.Operations.max, match.Groups[5].Value, match.Groups[3].Value);
                    SelectWhere selectWhere2 = new SelectWhere(match.Groups[2].Value, Utils.ToList(columnNames), condition2);
                    return selectWhere2;
                }
                if (match.Groups[4].Value.Equals("<"))
                {
                    Condition condition3 = new Condition(Condition.Operations.min, match.Groups[5].Value, match.Groups[3].Value);
                    SelectWhere selectWhere3 = new SelectWhere(match.Groups[2].Value, Utils.ToList(columnNames), condition3);
                    return selectWhere3;
                }
               
            }

            match = Regex.Match(miniSqlSentence, selectColumnsPattern);
            if (match.Success)
            {
                string[] columnNames = match.Groups[1].Value.Split(',');
                SelectColumns selectColumns = new SelectColumns(match.Groups[2].Value, Utils.ToList(columnNames));
                return selectColumns;
            }
            match = Regex.Match(miniSqlSentence, insertIntoPattern);
            if (match.Success)
            { 
                string[] columnNames = match.Groups[1].Value.Split(',');
                
                string[] list = match.Groups[2].Value.Split(',');
                Insert insert= new Insert(match.Groups[1].Value, Utils.ToList(list));
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
                if(match.Groups[3].Value.Equals("<"))
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

            return null;
        }
    }
}
