using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class SyntacticError : IQuery
    {

     
        public SyntacticError()
        {
          
        }


        public string Run(DB database)
        {

            return database.SyntacticError();
        }
    }
    
    
}
