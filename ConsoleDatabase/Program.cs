using System;
using System.Collections.Generic;
using System.IO;
using Database;
using Database.MiniSqlParser;
using System.Text.RegularExpressions;

namespace ConsoleDatabase
{
    class Program
    {

        private static DB db = new DB("Prueba");
        private static List<DB> dbList = new List<DB>();
        const string loginPattern = @"([a-zA-Z0-9]+),([a-zA-Z0-9]+),([a-zA-Z0-9]+)";

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input-file.txt");

            using (TextWriter writer = File.CreateText("output-file.txt"))
            {
                int numtest = 0;
                Console.WriteLine("# Test " + (numtest));
                writer.WriteLine("# Test " + (numtest));
                foreach (string line in lines)
                {
                    string queryResult = "";
                    Match match = Regex.Match(line, loginPattern);
                    if (match.Success)
                    {
                        string dbName = match.Groups[1].Value;
                        int num = FindDBWithName(dbName);
                        if (num == -1)
                        {
                            db = new DB(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                            dbList.Add(db);
                            writer.WriteLine("Database created");
                        }
                        else
                        {

                            db = dbList[FindDBWithName(dbName)];
                            queryResult = UseDatabaseConsole(line, db);
                            Console.WriteLine("# Test " + (numtest));
                            writer.WriteLine("# Test " + (numtest));
                        }
                    }
                  
                   if (line.Equals(""))
                    {
                        string close = "";
                        writer.WriteLine(close);
                        numtest++;
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
        private static int FindDBWithName(string dbName)
        {
            for (int i = 0; i < dbList.Count; i++)
            {
                if (dbList[i].GetName() == dbName)
                    return i;
            }
            return -1;
        }



    }
}

