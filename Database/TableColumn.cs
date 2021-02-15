using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class TableColumn
    {
        private List<String> Columns;
        public TableColumn()
        {
            Columns = new List<string>();
        }
        public List<String> GetColumn()
        {
            return Columns;
        }
        public void DeleteFrom()
        { 

        }
        public List<String> Select(List<String> listColumns, String condition)
        {
            return null;
        }
    }
}
