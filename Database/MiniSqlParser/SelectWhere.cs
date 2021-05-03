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
            if (database.SelectWhere(m_table, m_columnNames, m_condition) == null)
            {
                return "ERROR: Table does not exist";

            }
            else if (!database.GetSecurity().CheckUserAction(database.getUsername(), m_table, "SELECT"))
            {
                return "ERROR: Not sufficient priviledges";
            }
            else
            {
                return database.SelectWhere(m_table, m_columnNames, m_condition).ToString();
            }
        }
    
    }
}
