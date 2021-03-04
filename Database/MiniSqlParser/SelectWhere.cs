using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
   public class SelectWhere : IQuery
   {
        private string m_table;
        private string[] m_columnNames;

        public SelectWhere()
        { 
        
        }
        public string Run(DB database)
        {

            return null;
        }
   }
}
