using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
   public class Program
    {
       public static void Main(string[] args)
        {
            DB myDatabase = new DB("myDatabse");
            myDatabase.Save("fichero.txt");

            DB myDatabase2 = new DB("myDatabse");
            myDatabase.Load("fichero.txt");

        }
    }
}
