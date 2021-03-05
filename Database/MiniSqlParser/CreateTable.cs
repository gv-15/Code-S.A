using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class CreateTable : IQuery
    {

        private string m_table;
        private List<TableColumn> m_tableColumns;
        public CreateTable(string table, List<TableColumn> tableColumns)
        {
            //Falta por implementar todo, esta lo basico para hacer un run
            m_table = table;
            m_tableColumns = tableColumns;
        }


        public string Run(DB database)
        {

            // return database.CreateTable(m_table, m_tableColumns).toString();
            return null;
        }
    }
    
    
}
