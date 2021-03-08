using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
   public class SelectWhere : IQuery
    {
        private string m_table;
        private List<Table> m_columnNames;

        public SelectWhere(string table, List<Table> columnNames,Condition condition) //Falta la condition
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
