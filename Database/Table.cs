﻿using System;
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

        public  List<String> SelectRows(List<TableColumn> list, Condition condition)
        {
            return null;
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
