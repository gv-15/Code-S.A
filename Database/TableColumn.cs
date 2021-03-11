using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Database
{
    public class TableColumn
    {
        private List<string> m_columns;
        private String m_name;
        public TableColumn(string name)
        {
            m_name = name;
            m_columns = new List<string>();
        }

        public string GetTableColumnName()
        {
            return m_name;
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
                    if (int.TryParse(element, out int n))
                    {
                        if (int.Parse(element) < int.Parse(condition.GetValue()))
                        {
                            list2.Add(element);
                        }
                    }
                }


                else if (condition.GetOperation().Equals("max"))
                {
                    if (int.TryParse(element, out int n))
                    {
                        if (int.Parse(element) > int.Parse(condition.GetValue()))
                        {
                            list2.Add(element);
                        }
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

        public List<int> GetPositions(Condition condition)
        {
            List<int> positions = new List<int>();

            if (condition.GetOperation().Equals("equals"))
            {
                for (int i = 0; i < m_columns.Count; i++)
                {
                    if (condition.GetValue().Equals(m_columns.ElementAt(i)))
                    {
                        positions.Add(i);
                    }
                };
            }

            else if (condition.GetOperation().Equals("min"))
            {
                for (int i = 0; i < m_columns.Count; i++)
                {
                    if (condition.GetValue().CompareTo(m_columns.ElementAt(i)) == 1) //Este if no me inspira confianza
                    {
                        positions.Add(i);
                    }
                };
            }

            else if (condition.GetOperation().Equals("max"))
            {
                for (int i = 0; i < m_columns.Count; i++)
                {
                    if (condition.GetValue().CompareTo(m_columns.ElementAt(i)) == -1) //Este if tampoco me inspira confianza 
                    {
                        positions.Add(i);
                    }
                };
            }

            return positions;
        }

        public List<string> GetValues(List<int> positions)
        {
            List<string> list = new List<string>();
            foreach (int p in positions)
            {
                string value = m_columns.ElementAt(p);
                list.Add(value);
            }
            return list;
        }


    }
}
