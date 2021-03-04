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
        public DB(string name)
        {
           m_name = name;
           m_db = new List<Table>();

        }
        public Table GetTable()
        {

            return null;
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

        public void dropTable(Table table)
        {
            
            //Falta por implementarlo
        }


        public string Insert(string table, List<string> columns, List<string> values)
        {
            //Do whatever you have to do
            return null;
        }

        public Table SelectAll(string table)
        {
            return null;
        }

        public Table SelectColumns(string table, List<string> columnNames)
        {
            return null;
        }

        public string RunMiniSqlQuery(string query)
        {
            IQuery  queryObject = MiniSqlParser.Parser.Parse(query);

            return queryObject.Run(this);
        }


        public void Load(string filename)
        {
            string text = File.ReadAllText(filename);

            string[] values = text.Split(new Char[] { '\n' });


        }

        public void Save(string filename)
        {
            string text = null;
            for (int i = 0; i < 10; i++)
            {
                text += i.ToString() + "\n";

            }
            File.WriteAllText(filename, text);

        }

    }
}
