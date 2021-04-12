using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Update : IQuery
    {
        string m_table;
        Condition m_condition;
        List<string> m_columns;
        List<string> m_values;
        
        public Update(string table, Condition condition, List<string>  columns, List<string> values)
        {
            m_table = table;
            m_condition = condition;
            m_columns = columns;
            m_values = values;
        }


        public string Run(DB database)
        {

            return database.Update(m_columns, m_values, m_table, m_condition);
        }
    }
    
    
}
