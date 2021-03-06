﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class SelectAllWhere : IQuery
    {
        private string m_table;
        private Condition m_condition;
        public SelectAllWhere(string table, Condition condition)
        {
            m_table = table;
            m_condition = condition;
        }
        public string Run(DB database)
        {
            if (database.SelectAllWhere(m_table, m_condition) == null)
            {
                return "ERROR: Table does not exist";

            }
            else if (!database.GetSecurity().CheckUserAction(database.getUsername(), m_table, "SELECT"))
            {
                return "ERROR: Not sufficient priviledges";
            }
            else 
            {
                return database.SelectAllWhere(m_table, m_condition).ToString();
            }
        }

    }
}
