using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DropSecurityProfile : IQuery
    {
        private string sp;


        //Hay tres parametros pero solo le pasas un string en Parser
        public DropSecurityProfile(string profile)
        {
            sp = profile;
        }


        public string Run(DB database)
        {

             return database.GetSecurity().DropSecurityProfile(sp); 

          
        }
    }
    
    
}
