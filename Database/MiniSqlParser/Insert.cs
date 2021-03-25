using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Insert : IQuery
    {
        public string Table;
        public List<TableColumn> Columns = new List<TableColumn>();
        public List<string> Values = new List<string>();

        public Insert(string table, List<TableColumn> columns, List<string> values)
        {
            Table = table;
            Columns = columns;
            Values = values;
        }



        public string Run(DB database)
        {
            return database.InsertInto(Table, Columns, Values);
            
        }
    }
}