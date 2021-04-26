﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DropSecurityProfile : IQuery
    {
        private SecurityProfile sp;


        //Hay tres parametros pero solo le pasas un string en Parser
        public DropSecurityProfile(string profile,string password, List<Priviledge> priviledges)
        {
            SecurityProfile sp = new SecurityProfile(profile, password, priviledges);
        }


        public string Run(DB database)
        {

             return database.GetSecurity().DropSecurityProfile(sp); 

          
        }
    }
    
    
}
