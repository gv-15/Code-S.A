using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public static class Utils
    {
        public static List<string> ToList(string [] array)
        {
            List<string> list = new List<string>();
            foreach (string value in array)
                list.Add(value);
            return list;
        }
    }
}
