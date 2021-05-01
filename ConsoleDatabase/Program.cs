using System;
using System.Collections.Generic;
using System.IO;
using Database;
using Database.MiniSqlParser;

namespace ConsoleDatabase
{
    class Program
    {

        private static DB db;
        private static string contraseña;
        private static string nombreDB;
        private static string usuario;
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input-file.txt");

            /*
                        string stopCondition = "0";
                        Console.WriteLine("");
                        Console.WriteLine("If you wanna exit write --> CLOSE");
                        Console.WriteLine("");
                        Console.WriteLine("Enter a name for the Database");
                        nombreDB = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Enter a username");
                        usuario = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Enter a password");
                        contraseña = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Write the line you want to execute in the DB");
                        Console.WriteLine("");  
            */


            using (TextWriter writer = File.CreateText("output-file.txt"))
            {                     
                foreach(string line in lines)
                {
                    string queryResult = "";

                    if (line.Equals(""))
                    {
                            db = new DB(nombreDB, usuario, contraseña);
                         
                    }
                    else 
                    { 
             
       
                        queryResult = UseDatabaseConsole(line, db);
               
                    }

                        writer.WriteLine(queryResult);

                }
            }          
      }

        private static string UseDatabaseConsole(string miniSqlSentence, DB database)
        {

            IQuery IQ = Parser.Parse(miniSqlSentence);
        

            if (IQ != null)
            { 
                return IQ.Run(database);
            }
            return null;


        }
        


    }
}

