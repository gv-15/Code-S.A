using System;
using System.Collections.Generic;
using Database;
using Database.MiniSqlParser;

namespace ConsoleDatabase
{
    class Program
    {
        private static DB db;
      
        static void Main(string[] args)
        {
            
            string stopCondition = "0";
            Console.WriteLine("");
            Console.WriteLine("If you wanna exit write --> CLOSE");
            Console.WriteLine("");
            Console.WriteLine("Write the line you want to execute in the DB");
            Console.WriteLine("");
            
            if (db == null)
            {
                db = new DB("MyDB", "Admin", "SoyAdmin");
            }

            while (stopCondition != "1")
            {
                 
              string linea = Console.ReadLine();
              string queryResult = "";
                try
                {
                   queryResult = UseDatabaseConsole(linea, db);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Formato incorrecto");
                }
                stopCondition = queryResult;
                if(queryResult.Equals("1"))
                {
                    stopCondition = queryResult;
                }
                else
                {
                    Console.WriteLine(queryResult);

                }
              Console.WriteLine("");
            }
        }

        private static string UseDatabaseConsole(string miniSqlSentence, DB database)
        {

            IQuery IQ = Parser.Parse(miniSqlSentence);

            return IQ.Run(database);

        }


    }
}

