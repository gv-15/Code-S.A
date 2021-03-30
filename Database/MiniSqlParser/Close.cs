using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Close : IQuery
    {

     
        public Close()
        {
          
        }


        public string Run(DB database)
        {

            return database.Close();
        }
    }
    
    
}
