using System;
using System.Collections.Generic;
using System.IO;

namespace Database
{
    public class DB
    {
        private String Name;
        private List<Table> m_db;
        public DB(String name)
        {
           Name = name;
           m_db = new List<Table>();

        }
        public List<Table> GetDBTable()
        {

            return m_db;
        }

        public void AddTable(Table table)
        {
            m_db.Add(table);
        
        }

        public void Load(String filename)
        {
            String text = File.ReadAllText(filename);

            String[] values= text.Split(new Char[] { '\n' });
        
            
        }

        public void Save(String filename)
        {
            String text = null;
            for (int i = 0; i < 10; i++)
            {
              text += i.ToString() + "\n";

            }
            File.WriteAllText(filename, text);
        
        }
    }
}
