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

        public List<String> GetColumns()
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
            List<String> list2 = new List<String>();
           

            foreach (String element in list)
            {
                if (condition.GetOperation().Equals("equals"))
                {
                    if (element.Equals(condition.GetValue()))
                    {
                        list2.Add(element);
                    }
                }

                else if (condition.GetOperation().Equals("min"))
                {
                        if (int.Parse(element) < int.Parse(condition.GetValue()))
                        {
                            list2.Add(element);
                        }
                }
                        
                
                else if (condition.GetOperation().Equals("max"))
                {
                    
                        if (int.Parse(element) > int.Parse(condition.GetValue()))
                        {
                            list2.Add(element);
                        }
                    } 
            }
            foreach (String element in list2)
            {
                list.Remove(element);
            
            }
        }

        

        public List<String> Select(List<String> listColumns, Condition condition)
        {
            List<String> list1 = new List<String>();

            foreach (String element in listColumns)
            {
                if (condition.GetOperation().Equals("equals"))
                {

                    if (element.Equals(condition.GetValue()))
                    {
                        list1.Add(element);
                    }

                }
                else if (condition.GetOperation().Equals("min"))
                {
                        if (int.Parse(element) < int.Parse(condition.GetValue()))
                        {
                            list1.Add(element);
                        }
                    
                }
                else if (condition.GetOperation().Equals("max"))
                {
                    
                   if (int.Parse(element) > int.Parse(condition.GetValue()))
                   {
                      list1.Add(element);
                   }
                    
                }
            }
            return list1;
        }

    }
}
