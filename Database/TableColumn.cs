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
        private string m_name;
       

        public TableColumn(string name)
        {
            m_name = name;
            m_columns = new List<string>();
        }

        public string GetTableColumnName()
        {
            return m_name;
        }

        public List<string> GetColumns()
        {
            return m_columns;
        }

        public void DeleteFrom(string p)
        {
            m_columns.Remove(p);
        }

        public void AddString(string parameter)
        {
            m_columns.Add(parameter);
        }

        public void DeleteCondition(List<string> list, Condition condition)
        {
            List<string> list2 = new List<string>();


            foreach (string element in list)
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
            foreach (string element in list2)
            {
                list.Remove(element);

            }
        }



        public List<string> Select(Condition condition)
        {
            List<string> list1 = new List<string>();

            foreach (string element in m_columns)
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
