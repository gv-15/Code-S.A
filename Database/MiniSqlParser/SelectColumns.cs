using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
   public class SelectColumns : IQuery
   {
        private string m_table;
        private string[] m_columnNames;

        public SelectColumns(string table, string[] columnNames)
        {
            m_table = table;
            m_columnNames = columnNames;
        }
        public string Run(DB database)
        {

            return null;
        }
   }
}
