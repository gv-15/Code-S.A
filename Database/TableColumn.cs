﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class TableColumn
    {
        private List<String> Columns;
        public TableColumn()
        {
            Columns = new List<string>();
        }
        public List<String> GetColumn()
        {
            return Columns;
        }
        public void DeleteFrom()
        { 

        }
        
    }
}
