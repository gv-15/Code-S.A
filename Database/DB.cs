using System;
using System.Collections.Generic;

namespace Database
{
    public class DB
    {

        private List<Table> m_db;
        public DB()
        {

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
       
    }
}
