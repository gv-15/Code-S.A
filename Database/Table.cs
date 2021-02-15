using System;
using System.Collections.Generic;

namespace Database
{
    public class Table
    {
        private String Name;
        private List<TableColumn> columns; 

        public Table(String name)
        {
            Name = name;
            columns = new List<TableColumn>();


        }

        public void AddColumn(TableColumn column)
        {
            columns.Add(column);
        }

        public  List<int> SelectRows(List<TableColumn> list, String condition)
        {
            return null;
        }

        public void DeleteRows(List<TableColumn> list, String condition)
        {
           
        }

    }
}
