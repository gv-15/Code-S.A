using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class TableColumn
    {
        private List<String> m_columns;
        private String m_name;
        public TableColumn(String name)
        {
            m_name = name;
            m_columns = new List<string>();
        }
        public List<String> GetColumn()
        {
            return m_columns;
        }
        public void DeleteFrom()
        { 

        }
        public void AddString()
        {

        }
        public void DeleteCondition(List<String> list, Condition condition)
        {

        }
        
        public List<String> Select(List<String> listColumns, Condition condition)
        {
            return null;
        }

    }
}
