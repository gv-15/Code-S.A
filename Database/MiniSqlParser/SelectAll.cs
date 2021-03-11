using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{ 
        public class SelectAll : IQuery
        {
            private string m_table;

            public String Table()
            {
                return m_table;
            }


            public SelectAll(string table)
            {
             m_table = table;
            }
        
            public string TableName()
            {
                return m_table;
            }

            public string Run(DB database)
            {

            return database.GetTableWithName(m_table).ToString();
            //Aqui devuelve un lista de tableColumns y eso falta por pasarlo a string del .ToString() no hace lo que deberia ahi que sobreescribirlo en otro metodo 
            }
        }
}
