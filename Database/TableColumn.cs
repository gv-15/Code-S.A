using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class TableColumn
    {
        private List<String> Columns;
        private String Name;
        public TableColumn(String name)
        {
            Name = name;
            Columns = new List<string>();
        }
        public List<String> GetColumn()
        {
            return Columns;
        }
        public void DeleteFrom()
        { 

        }
        public void AddColumn()
        {

        }
        public void DeleteCondition(List<String> List, String Condition)
        {

        }
        
        public List<String> Select(List<String> listColumns, String condition)
        {
            return null;
        }
    }
}
