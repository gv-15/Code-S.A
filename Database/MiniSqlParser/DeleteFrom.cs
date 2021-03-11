using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DeleteFrom : IQuery
    {
        private string m_table;
        private List<string> m_columnNames;
        public DeleteFrom(string table, List<string> columnNames) //Falta la condition
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
