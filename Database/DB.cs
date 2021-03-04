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
        public List<Table> GetDBTable()
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

        public void Load(string filename)
        {
            string text = File.ReadAllText(filename);

            string[] values= text.Split(new Char[] { '\n' });
        
            
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
