﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Database
{
    public class Table
    {
        private string m_name;
        private List<TableColumn> m_columns;
        private List<String> rows = new List<string>();

        public Table(String name)
        {
            m_name = name;
            m_columns = new List<TableColumn>();

        }

        public Table(String name, List<TableColumn> tableColumns)
        {
            m_name = name;
            m_columns = tableColumns;

        }

        public void AddColumn(TableColumn column)
        {
            m_columns.Add(column);
        }

        public List<int> SelectRowsPositions(Condition condition)
        {
          
            List<String> columnslist = new List<String>();
            List<int> position = new List<int>();

            foreach (TableColumn element in m_columns)
            {
                int counter = 0;

                columnslist = element.GetColumns();

                foreach (String element2 in columnslist)
                {
                    if (condition.GetOperation().Equals("equals"))
                    {
                        if (element2.Equals(condition.GetValue()))
                        {
                            if (!position.Contains(counter))
                            {
                                position.Add(counter);
                            }
                        }
                    }
                    else if (condition.GetOperation().Equals("max"))
                    {
                        if (int.TryParse(element2, out int n))
                        { 
                            if (int.Parse(element2) > int.Parse(condition.GetValue()))
                            {
                                if (!position.Contains(counter))
                                {
                                    position.Add(counter);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (int.TryParse(element2, out int n))
                        {
                            if (int.Parse(element2) < int.Parse(condition.GetValue()))
                            {
                                if (!position.Contains(counter))
                                {
                                    position.Add(counter);
                                }
                            }
                        }
                    }
                    counter++;
                }

                
            }
            //Ordenamos la lista de menor a mayor. A la hora de usar Delete hay que recorrer la lista de mayor a menor.
            position.Sort();
            return position;
        }


        public void DeleteRows(List<TableColumn> list, Condition condition)
        {

     

        }
        public String GetName() 
        {
            return m_name;
        }

        public List<TableColumn> GetColumns()
        {
            return m_columns;
        }
    }
}
