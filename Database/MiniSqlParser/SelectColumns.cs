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

            return database.SelectColumns(m_table,m_columnNames).ToString();
        }
   }
}
