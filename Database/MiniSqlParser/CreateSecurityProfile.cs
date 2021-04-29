using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class CreateSecurityProfile : IQuery
    {

        private string sp;

        //Problema: tienes tres parámetros pero en parser sólo le pasas un string profile
        public CreateSecurityProfile(string profile)
        {

            sp = profile;
        }


        public string Run(DB database)
        {
            return database.GetSecurity().CreateSecurityProfile(sp);
            
        }
    }
    
    
}
