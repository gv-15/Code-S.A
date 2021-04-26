using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class CreateSecurityProfile : IQuery
    {
        private string m_profile;

        public CreateSecurityProfile(string profile)
        {
            m_profile = profile;
        }


        public string Run(DB database)
        {
            //return database.GetSecurity().CreateSecurityProfile(m_profile);  profile has to be a string
            return null;
        }
    }
    
    
}
