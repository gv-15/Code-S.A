using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Insert : IQuery
    {
        public string Table;
        public List<string> Values = new List<string>();

        public Insert(string table, List<string> values)
        {
            Table = table;
            Values = values;
        }



        public string Run(DB database)
        {
            return database.InsertInto(Table,Values);
            
        }
    }
}