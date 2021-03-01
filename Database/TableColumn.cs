﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        public List<String> SelectMatches(Condition condition)
        {
            List<String> lista = new List<String>();
            List<String> list2 = new List<String>();
            list2 = this.GetColumns();
            foreach (String element2 in list2)
            {
                if (condition.GetOperation().Equals("equals"))
                {
                    if (element2.Equals(condition.GetValue()))
                    {
                        lista.Add(element2);
                    }
                }
                else if (condition.GetOperation().Equals("max"))
                {
                    Regex regex = new Regex(@"^[0-9]$");

                    if (regex.IsMatch(element2))
                    {
                        if (int.Parse(element2) > int.Parse(condition.GetValue()))
                        {
                            list2.Add(element2);
                        }
                    }
                }
                else
                {
                    Regex regex = new Regex(@"^[0-9]$");

                    if (regex.IsMatch(element2))
                    {
                        if (int.Parse(element2) < int.Parse(condition.GetValue()))
                        {
                            list2.Add(element2);
                        }

                    }


                }

            }
            return lista;
        }
    }
}
