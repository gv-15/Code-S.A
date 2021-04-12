using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Sintacticerror : IQuery
    {

     
        public Sintacticerror()
        {
          
        }


        public string Run(DB database)
        {

            return database.Sintacticerror();
        }
    }
    
    
}
