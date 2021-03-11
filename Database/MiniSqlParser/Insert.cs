using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Insert : IQuery
    {
        public string Table = null;
        public List<TableColumn> Columns = null;
        public List<string> Values = null;

        public Insert(string table, List<TableColumn> columns, List<string> values)
        {
            Table = table;
            Columns = columns;
            Values = values;
        }

        public string Run(DB database)
        {
            return database.Insert(Table, Columns, Values);
            
        }
    }
}