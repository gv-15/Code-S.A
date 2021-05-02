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
                TimeSpan totalTime = new TimeSpan(0);
                TimeSpan totalTimeTotal = new TimeSpan(0);
                int numtest = 1 ;
                writer.WriteLine("# Test " + (numtest));
                DateTime startTotal = DateTime.Now;
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
                            DateTime start = DateTime.Now;
                            db = new DB(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                            dbList.Add(db);
                            DateTime end = DateTime.Now;
                            TimeSpan ts = (end - start);
                            totalTime += ts;
                            writer.WriteLine("Database created" + " (" + ts.TotalSeconds + "s)");
                        }
                        else
                        {

                            db = dbList[FindDBWithName(dbName)];
                            queryResult = UseDatabaseConsole(line, db);
                            writer.WriteLine("# Test " + (numtest));
                        }
                    }
                  
                   if (line.Equals(""))
                    {
                        string close = ""; 
                        numtest++;
                        writer.WriteLine("TOTAL TIME: " + totalTime.TotalSeconds + "s");
                        writer.WriteLine(close);
                        totalTime = new TimeSpan(0);
                    }
                    else 
                    {

                        DateTime start = DateTime.Now;
                        queryResult = UseDatabaseConsole(line, db);
                        DateTime end = DateTime.Now;
                        TimeSpan ts = (end - start);
                        totalTime += ts;
                        writer.WriteLine(queryResult + " (" + ts.TotalSeconds + "s)");
                      
               
                    }

                }
                DateTime endTotal = DateTime.Now;
                TimeSpan ts1 = (endTotal - startTotal);
                writer.WriteLine("TOTAL TIME: " + ts1.TotalSeconds + "s");
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

