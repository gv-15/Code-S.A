using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Grant : IQuery
    {
        private string m_profile;
        private string m_table;

        public Grant(string profile, string table)
        {
            m_profile = profile;
            m_table = table;
            
        }


        public string Run(DB database)
        {

            return database.GetSecurity().Grant(m_profile,m_table); 

            
        }
    }
    
    
}
