using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class CreateSecurityProfile : IQuery
    {

        private SecurityProfile sp;

        //Problema: tienes tres parámetros pero en parser sólo le pasas un string profile
        public CreateSecurityProfile(string profile, string password, List<Priviledge> priviledges)
        {
       
          sp = new SecurityProfile(profile, password, priviledges);
        }


        public string Run(DB database)
        {
            return database.GetSecurity().CreateSecurityProfile(sp);
            
        }
    }
    
    
}
