using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class Program
    {
      static void Main(string[] args)
        {
            DB myDatabase = new DB("myDatabase");
            myDatabase.Save("fichero.txt");

            DB myDatabase2 = new DB("myDatabase2");
            myDatabase2.Save("fichero.txt");
        }
    }
}
