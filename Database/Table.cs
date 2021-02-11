using System;
using System.Collections.Generic;

namespace Database
{
    public class Table
    {
        private List<TableColumn> columns; 
        public Table()
        {
            columns = new List<TableColumn>();


        }

        public void AddColumn(TableColumn column)
        {
            columns.Add(column);
        }

        public List<TableColumn> GetColumnsTable(List<TableColumn> tablecolumn)
        {

            return tablecolumn;
        }


    }
}
