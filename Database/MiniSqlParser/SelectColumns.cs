using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
   public class SelectColumns : IQuery
   {
        private string m_table;
        private List<string> m_columnNames;

        public SelectColumns(string table, List<string> columnNames)
        {
            m_table = table;
            m_columnNames = columnNames;
        }
        public string Run(DB database)
        {
            if (database.SelectColumns(m_table, m_columnNames) == null)
            {
                return "ERROR: Table does not exist";

            }
            else if (!database.GetSecurity().CheckUserAction(database.getUsername(), m_table, "SELECT"))
            {
                return "ERROR: Not sufficient priviledges";
            }
            else 
            {
            return database.SelectColumns(m_table,m_columnNames).ToString();
            }
        }
   }
}
