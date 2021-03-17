using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
   public class SelectWhere : IQuery
    {
        private string m_table;
        private List<string> m_columnNames;
        private Condition m_condition;
        public SelectWhere(string table, List<string> columnNames,Condition condition) 
        {
            m_table = table;
            m_columnNames = columnNames;
            m_condition = condition;
        }
        public string Run(DB database)
        {

            return database.SelectWhere(m_table,m_columnNames,m_condition).ToString();
        }
    
    }
}
