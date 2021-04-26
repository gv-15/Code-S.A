using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DropSecurityProfile : IQuery
    {
        private string m_profile;

        public DropSecurityProfile(string profile)
        {
            m_profile = profile;
        }


        public string Run(DB database)
        {

            // return database.GetSecurity().DropSecurityProfile(m_profile);  //Falta cambiar a string en security

            return null;
        }
    }
    
    
}
