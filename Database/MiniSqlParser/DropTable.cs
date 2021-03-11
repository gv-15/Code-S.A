using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DropTable : IQuery
    {
        private string tableName;
        public DropTable(string name)
        {
            tableName = name;
        }


        public string Run(DB database)
        {
            return database.dropTable(tableName);
           
        }
    }
}
