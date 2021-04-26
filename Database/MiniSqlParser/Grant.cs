using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Grant : IQuery
    {
        private string m_profile;
        private string m_table;
        private Enum m_priviledfeType;

        public Grant(string profile, string table, Enum priviledgeType)
        {
            m_profile = profile;
            m_table = table;
            m_priviledfeType = priviledgeType;
        }


        public string Run(DB database)
        {

            return database.GetSecurity().Grant(m_profile,m_table, m_priviledfeType); 

            
        }
    }
    
    
}
