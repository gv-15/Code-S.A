using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DeleteFrom : IQuery
    {
        private string m_table;
        private List<string> m_columnNames = new List<string>();
        private Condition m_condition;
        public DeleteFrom(string table, List<string> columnNames,Condition condition) //Falta la condition
        {
            m_table = table;
            m_columnNames = columnNames;
            m_condition = condition;
        }

        public string Run(DB database)
        {
            return database.DeleteFrom(m_table,m_columnNames,m_condition);
        }
    }
}
