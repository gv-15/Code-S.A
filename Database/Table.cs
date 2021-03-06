﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Database
{
    public class Table
    {
        private string m_name;
        private List<TableColumn> m_columns;
    

        public Table(string name)
        {
            m_name = name;
            m_columns = new List<TableColumn>();
          

        }

        public Table(string name, List<TableColumn> tableColumns)
        {
            m_name = name;
            m_columns = tableColumns;
            
        }


        public void AddColumn(TableColumn column)
        {
            m_columns.Add(column);
        }

        public void AddRow(List<string> values)
        {
            if (values.Count == m_columns.Count)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    string value = values.ElementAt(i);
                    m_columns.ElementAt(i).AddString(value);
                }
            }

        }

        public TableColumn GetColumnWithName(string name)
        {
            int position = FindColumnWithName(name);
            return m_columns[position];
        }

        public int FindColumnWithName(string columnName)
        {
            for (int i = 0; i < m_columns.Count; i++)
            {
                if (m_columns[i].GetTableColumnName() == columnName)
                    return i;
            }
            return -1;
        }

        public List<int> SelectRowsPositions(Condition condition)
        {

            List<string> columnslist = new List<string>();
            List<int> position = new List<int>();

            foreach (TableColumn element in m_columns)
            {
                int counter = 0;
                if (element.GetTableColumnName().Equals(condition.GetColumnName()))
                {
                    columnslist = element.GetColumns();
                    string tcc = "";
                    string tcc2 = "";
                    foreach (string element2 in columnslist)
                    {
                        tcc = element2.Replace("'", "");
                        tcc2 = tcc.Replace("\"", "");
                        if (condition.GetOperation().Equals("equals"))
                        {
                            
                            if (tcc2.Equals(condition.GetValue()))
                            {
                                if (!position.Contains(counter))
                                {
                                    position.Add(counter);
                                }
                            }
                        }
                        else if (condition.GetOperation().Equals("max"))
                        {
                            if (int.TryParse(tcc2, out int n))
                            {
                                if (int.Parse(tcc2) > int.Parse(condition.GetValue()))
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
                            if (int.TryParse(tcc2, out int n))
                            {
                                if (int.Parse(tcc2) < int.Parse(condition.GetValue()))
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

            }
            //Ordenamos la lista de menor a mayor. A la hora de usar Delete hay que recorrer la lista de mayor a menor.
            position.Sort();
            return position;
        }

        public void DeleteColumn(Condition condition)
        {
            List<int> index = SelectRowsPositions(condition);
            foreach (TableColumn column in GetColumns())
            {
                for (int i = index.Count - 1; i >= 0; i--)
                {
                    column.GetColumns().RemoveAt(index[i]);
                }
            }
        }



        public string GetName()
        {
            return m_name;
        }

        public List<TableColumn> GetColumns()
        {
            return m_columns;
        }


        public override string ToString()
        {
            string resultadoFinal = "[";
            foreach (TableColumn column in m_columns)
            {
                if (column != m_columns.Last())
                {
                    string columnName = column.GetTableColumnName();
                    resultadoFinal += "'" + columnName + "',";
                }
                else
                {
                    string ColumnName = column.GetTableColumnName();
                    resultadoFinal += "'" + ColumnName + "'";
                }
            }
            resultadoFinal += "]";
            for (int i = 0; i < m_columns.ElementAt(0).GetColumns().Count; i++)
            {
                foreach (TableColumn tc in m_columns)
                {
                    if (tc == m_columns.First())
                    {
                        if (tc == m_columns.Last())
                        {
                            if(int.TryParse(tc.GetColumns().ElementAt(i), out int n))
                            { 
                            resultadoFinal += "{'" + tc.GetColumns().ElementAt(i) + "'}";
                            }
                            else
                            {
                             resultadoFinal += "{" + tc.GetColumns().ElementAt(i) + "}";
                            }
                        }
                        else
                        {
                            if (int.TryParse(tc.GetColumns().ElementAt(i), out int n))
                            {
                                resultadoFinal += "{'" + tc.GetColumns().ElementAt(i) + "',";
                            }
                            else
                            {
                                resultadoFinal += "{" + tc.GetColumns().ElementAt(i) + ",";
                            }
                        }
                    }
                    else if (tc != m_columns.Last())
                    {
                        if (int.TryParse(tc.GetColumns().ElementAt(i), out int n))
                        {
                            resultadoFinal += "'" + tc.GetColumns().ElementAt(i) + "',";
                        }
                        else
                        {
                            resultadoFinal += "" + tc.GetColumns().ElementAt(i) + ",";
                        }
                    }

                    else
                    {
                        if (int.TryParse(tc.GetColumns().ElementAt(i), out int n))
                        {
                            resultadoFinal += "'" + tc.GetColumns().ElementAt(i) + "'}";
                        }
                        else
                        {
                            resultadoFinal += "" + tc.GetColumns().ElementAt(i) + "}";

                        }
                    }
                }
            }
            return resultadoFinal;
        }
    }
}