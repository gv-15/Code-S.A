﻿using Database.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Database
{
    public class DB
    {
        const string Pattern1 = @"([a-zA-Z0-9]+) TEXT";
        const string Pattern2 = @"([a-zA-Z0-9]+) INT";
        const string Pattern3 = @"([a-zA-Z0-9]+) DOUBLE";
        const string Pattern4 = @"([a-zA-Z0-9]+)";
        private string m_name;
        private List<Table> m_db;
        private string m_username;
        private string m_password;
        public DB(string name)
        {
            m_name = name;
            m_db = new List<Table>();

        }

        public DB(string name, string username, string password)
        {
            m_name = name;
            m_username = username;
            m_password = password;
            m_db = new List<Table>();

        }

        public Table GetTableWithName(string name)
        {
            int position = FindTableWithName(name);
            return m_db[position];
        }

        public Table GetTable(int position)
        {
            return m_db[position];
        }

        public List<Table> GetDBTableList()
        {

            return m_db;
        }

        public string GetDBname()
        {

            return m_name;
        }

        public void AddTable(Table table)
        {
            m_db.Add(table);

        }

        public string DropTable(string tableName)
        {
            string respuesta = "Table erased";
            m_db.RemoveAt(FindTableWithName(tableName));
            return respuesta;
        }

        public string Close()
        {
            string respuesta = "1";
            return respuesta;
        }

        public string CreateTable(string nameOfTable, List<TableColumn> tableColumns)
        {
            List<TableColumn> tableColumns2 = new List<TableColumn>();
            string respuesta = "Table created";

            TableColumn[] arrayTC = tableColumns.ToArray();

            foreach (TableColumn column in arrayTC)
            {
                

                 string value = column.GetTableColumnName();
                 Match match1 = Regex.Match(value, Pattern4);
                 Match match = Regex.Match(value, Pattern1);
                 Match match2 = Regex.Match(value, Pattern2);
                 Match match3 = Regex.Match(value, Pattern3);

                 

               if (match.Success)
                 {
                     string tcc = value.Replace(" TEXT","");
                     TableColumn tc = new TableColumn(tcc);
                     tableColumns2.Add(tc);
                     Table table1 = new Table(nameOfTable, tableColumns2);
                     m_db.Add(table1);

                 }


                 else if (match2.Success)
                 {
                     string tcc = value.Replace(" INT", "");
                     TableColumn tc = new TableColumn(tcc);
                     tableColumns2.Add(tc);
                     Table table2 = new Table(nameOfTable, tableColumns2);
                     m_db.Add(table2);

                 }

                 else if (match3.Success)
                 {
                     string tcc = value.Replace(" DOUBLE", "");
                     TableColumn tc = new TableColumn(tcc);
                     tableColumns2.Add(tc);
                     Table table3 = new Table(nameOfTable, tableColumns2);
                     m_db.Add(table3);

                 }

                else if (match1.Success)
                {
                    Table table = new Table(nameOfTable, tableColumns);
                    m_db.Add(table);
                }


            }


            return respuesta;

        }

        public int FindTableWithName(string tableName)
        {
            for (int i = 0; i < m_db.Count; i++)
            {
                if (m_db[i].GetName() == tableName)
                    return i;
            }
            return -1;
        }


        public string InsertInto(string table, List<string> values)
        {
            string resultado = "";
            int i = FindTableWithName(table);
            if (i == -1)
            {
                resultado = "ERROR: Table doesn't exist ";
            }
            else
            {
                resultado = "Tuple added";
                Table t = new Table(m_db[i].GetName());
                t = m_db[i];
                string st = "";
                List<string> columnNames = new List<string>();
                foreach (TableColumn tc in t.GetColumns())
                {
                    columnNames.Add(tc.GetTableColumnName());
                }

                Table tableColumns = SelectColumns(t.GetName(), columnNames);
                List<TableColumn> list = tableColumns.GetColumns();

                for (int c = 0; c < list.Count; c++)
                {
                    list[c].AddString(values[c]);
                    st += values[c];
                }
            }

            return resultado;
        }

        public Table SelectAll(string table)
        {
            int i = FindTableWithName(table);

            return m_db[i];
        }

        public Table SelectColumns(string table, List<string> columnNames)
        {
            Table newTable = new Table("newTable");

            int p = FindTableWithName(table);

            Table t = new Table("t"); 
            t=this.GetTable(p);
            List<TableColumn> list = new List<TableColumn>();
            list = t.GetColumns();
           
            for (int i = 0; i < columnNames.Count; i++)
            {
                string name = columnNames[i];

                foreach (TableColumn col in list)
                {
                    if (col.GetTableColumnName().Equals(name))
                    {
                        newTable.AddColumn(col);

                    }
                }
            }

            List<TableColumn> columns = new List<TableColumn>();
            columns = newTable.GetColumns();
            int n = columns.Count;
            int b = columns[0].GetColumns().Count;
                      
            List<String> li = new List<string>();
            List<List<string>> li2 = new List<List<string>>();

            for (int j = 0; j < b; j++)
            {

                for (int k = 0; k < n; k++) 
                { 
                 string s = columns[k].GetColumns()[j];
                 li.Add(s);
                }

                li2.Add(li);
                
            }

            return newTable;
        }

            public string DeleteFrom(string table, List<string> columnNames, Condition condition)
            {
                string resultado = "Tuple(s) deleted";
                int p = FindTableWithName(table);
                Table t = this.GetTable(p);
                List<TableColumn> list = t.GetColumns();


                t.DeleteColumn(condition);

            return resultado;
            }

            public string RunMiniSqlQuery(string query)
            {
       

            IQuery queryObject = MiniSqlParser.Parser.Parse(query);
            
          
            return queryObject.Run(this);

            }

        public Table SelectWhere(string table, List<string> columnNames, Condition condition)
        {
            Table FilteredColumnTable = SelectColumns(table, columnNames);
            Table newTable = new Table("newTable");



            List<int> index = FilteredColumnTable.SelectRowsPositions(condition);
            TableColumn newColumn;
            List<string> values;
            foreach (TableColumn column in FilteredColumnTable.GetColumns())//Columnas de NewTable
            {
                values = new List<string>();
                newColumn = new TableColumn(column.GetTableColumnName());
                foreach (int row in index)
                {
                    values.Add(column.GetColumns()[row]);
                }
                foreach (string value in values)
                {
                    newColumn.AddString(value);
                }
                newTable.AddColumn(newColumn);

            }

            return newTable;
        }

        public Table SelectAllWhere(String table, Condition condition)
        {
            int i = FindTableWithName(table);
            Table selectedTable = m_db[i];
            Table newTable = new Table("new");

            List<int> index = selectedTable.SelectRowsPositions(condition);


            TableColumn newColumn;
            List<string> values;
            foreach (TableColumn column in selectedTable.GetColumns())//Columnas de NewTable
            {
                values = new List<string>();
                newColumn = new TableColumn(column.GetTableColumnName());
                foreach(int row in index)
                {
                    values.Add(column.GetColumns()[row]);
                }
                
                foreach (string value in values)
                {
                    newColumn.AddString(value);
                }
                newTable.AddColumn(newColumn);

            }

            return newTable;

        }

        public DB Load(string directory, string name, string newName)
        {
            Table t;
            TableColumn tc;
            DB db = new DB(newName, "Admin2", "Admin2");
          
            //La base de datos que se va a generar es la de arriba con el nombre que le hayas dado.

            if (Directory.Exists(directory))
            {
                foreach (string directorie in Directory.GetDirectories(name))
                {

                    string[] directories = directorie.Split(new char[] { '\\' });
                    t = new Table(directories[1], new List<TableColumn>());
                    string[] directorieFiles = Directory.GetFiles(directorie);

                    foreach (string file in directorieFiles)
                    {

                            string fileText = File.ReadAllText(file);
                            string[] fileValues = fileText.Split(new char[] { ',' });
                            string concatenatedValues = "";
                            string[] valuesSplitCommas;

                        for (int i = 0; i <= fileValues.Length - 1; i++)
                        {

                            fileValues[i] = fileValues[i].Replace("[[delimiter]]", ",");
                            concatenatedValues += fileValues[i] + ",";
                        }

                        valuesSplitCommas = concatenatedValues.Split(new char[] { ',' });
                        string[] files = file.Split(new char[] { '\\' });
                        tc = new TableColumn(files[2]);

                        for (int i = 0; i < valuesSplitCommas.Length; i++)
                        {

                            if (i != 0 && i % 2 == 0)
                            {

                                tc.AddString(valuesSplitCommas[i]);
                            }
                        }
                        t.AddColumn(tc);
                    }
                    db.AddTable(t);
                }
            }
            return db;
        }

        public void Save()
        {
            string namesOfTables = null;
            string columnValue = null;
            string nameOfColumn = null;
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            if (!Directory.Exists(path +"\\"+ GetDBname()))
                Directory.CreateDirectory(path + "\\" + GetDBname());
                string directory = GetDBname();

            foreach (Table table in m_db)
            {
                string tableDirectory = directory + "\\" + table.GetName();

                if (!Directory.Exists(tableDirectory))
                    Directory.CreateDirectory(tableDirectory);
                    string tableName = "tableName," + table.GetName();
                    namesOfTables += tableName.Replace(",", "[[delimiter]]") + ",";

                foreach (TableColumn column in table.GetColumns())
                {
                    columnValue = null;
                    string tableColumnNames = "tableColumnNames," + column.GetTableColumnName();
                    nameOfColumn += tableColumnNames.Replace(",", "[[delimiter]]") + ",";
                    string tableColumnDirectory =  directory + "\\" + tableDirectory + "\\" + column.GetTableColumnName();
                    foreach (string value in column.GetColumns())
                    {
                        string tableColumnVal = "tableColumnVal," + value;
                        columnValue += tableColumnVal.Replace(",", "[[delimiter]]") + ",";
                    }
                   
                    File.WriteAllText(tableDirectory+"\\"+column.GetTableColumnName() + ".txt",  "[[delimiter]]" + columnValue);
                }
            }
        }

    }

}