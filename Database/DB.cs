using Database.MiniSqlParser;
using System;
using System.Collections.Generic;
using System.IO;

namespace Database
{
    public class DB
    {
        private string m_name;
        private List<Table> m_db;
        private String m_username;
        private String m_password;
        public DB(string name)
        {
            m_name = name;
            m_db = new List<Table>();

        }

        public DB(string name, String username, String password)
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

        public string dropTable(String tableName)
        {
            string respuesta = "Tabla borrada correctamente";
            m_db.RemoveAt(FindTableWithName(tableName));
            return respuesta;
        }

        public string CreateTable(String nameOfTable, List<TableColumn> tableColumns)
        {
            string respuesta = "Tabla creada correctamente";
            Table table = new Table(nameOfTable, tableColumns);
            m_db.Add(table);
            return respuesta;
        }

        public int FindTableWithName(String tableName)
        {
            for (int i = 0; i < m_db.Count; i++)
            {
                if (m_db[i].GetName() == tableName)
                    return i;
            }
            return -1;
        }


        public string Insert(string table, List<TableColumn> columns, List<string> values)
        {
            String st = "";
            int i = FindTableWithName(table);
            Table t = GetTable(i);
            List<String> columnNames = null;

            foreach (TableColumn tc in columns)
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

            return st;
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

            Table t = this.GetTable(p);
            List<TableColumn> list = t.GetColumns();

            for (int i = 0; i < columnNames.Count; i++)
            {
                String name = columnNames[i];

                foreach (TableColumn col in list)
                {
                    if (col.GetTableColumnName().Equals(name))
                    {
                        newTable.AddColumn(col);
                    }
                }
            }

            return newTable;
        }


        public void DeleteFrom(string table, List<string> columnNames, Condition condition)
        {

            int p = FindTableWithName(table);
            Table t = this.GetTable(p);
            List<TableColumn> list = t.GetColumns();

            for (int i = 0; i < columnNames.Count; i++)
            {
                string name = columnNames[i];
                foreach (TableColumn col in list)
                {
                    if (col.GetTableColumnName().Equals(name))
                    {
                        t.DeleteRows(list, condition);
                    }
                }

            }
        }

        public string RunMiniSqlQuery(string query)
        {
            IQuery queryObject = MiniSqlParser.Parser.Parse(query);

            return queryObject.Run(this);
        }


        public void Load(string filename)
        {
            string text = File.ReadAllText(filename);

            string[] values = text.Split(new Char[] { '\n' });


        }

        public void Save()
        {
            string namesOfTables = null;
            string columnValue = null;
            string nameOfColumn = null;

            if (!Directory.Exists(GetDBname()))
                Directory.CreateDirectory(GetDBname());
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
                    string tableColumnDirectory = directory + "\\" + tableDirectory + "\\" + column.GetTableColumnName();
                    string tableColumnNames = "tableColumnNames," + column.GetTableColumnName();
                    nameOfColumn += tableColumnNames.Replace(",", "[[delimiter]]") + ",";

                    foreach (string value in column.GetColumns())
                    {
                        string tableColumnVal = "tableColumnVal," + value;
                        columnValue += tableColumnVal.Replace(",", "[[delimiter]]") + ",";
                    }
                    File.WriteAllText(tableColumnDirectory, column.GetType() + "[[delimiter]]" + columnValue);
                }
            }
        }

    }

}