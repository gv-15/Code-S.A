using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{ 
        public class SelectAll : IQuery
        {
            private string m_table;

            public String Table()
            {
                return m_table;
            }


            public SelectAll(string table)
            {
             m_table = table;
            }
        
            public string TableName()
            {
                return m_table;
            }

            public string Run(DB database)
            {

            //return database.GetTable(m_table).toString();
            return null;
            }
        }
}
