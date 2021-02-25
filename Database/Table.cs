using System;
using System.Collections.Generic;

namespace Database
{
    public class Table
    {
        private String m_name;
        private List<TableColumn> m_columns; 

        public Table(String name)
        {
            m_name = name;
            m_columns = new List<TableColumn>();


        }

        public void AddColumn(TableColumn column)
        {
            m_columns.Add(column);
        }

        public  List<String> SelectRows(Condition condition)
        {
            List<String> list2 = new List<String>();
            List<String> lista = new List<String>();

            foreach (TableColumn element in m_columns)
            {
                list2 = element.GetColumn();
                foreach (String element2 in list2)
                {
                    if (condition.GetOperation().Equals("equals"))
                    {
                        if (element.Equals(condition.GetValue()))
                        {
                            lista.Add(element2);
                        }
                    }
                }
                
            }
            
            return lista;
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
