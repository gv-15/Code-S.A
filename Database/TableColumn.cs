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
            m_columns = new List<String>();
        }

        public List<String> GetColumn()
        {
            return m_columns;
        }

        public void DeleteFrom(String p)
        {
            m_columns.Remove(p);
        }

        public void AddString(String parameter)
        {
            m_columns.Add(parameter);
        }

        public void DeleteCondition(List<String> list, Condition condition)
        {
            foreach (String element in list)
            {
                
            
            }
            

        }
        
        public List<String> Select(List<String> listColumns, Condition condition)
        {
            List<String> list1 = new List<String>();

            if(condition.GetOperation().Equals("equals"))
            {
                foreach(String element in listColumns)
                {
                    if (element.Equals(condition.GetValue()))
                    {
                        list1.Add(element);
                    }
                }

            }

            return list1;
        }

    }
}
