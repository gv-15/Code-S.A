using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
   public class Condition
    {

        private Enum Operator;
        private String Value;
        private TableColumn ColumnName;
        public Condition(Enum operation, String value, TableColumn column)
        {
            Operator = operation;
            Value = value;
            ColumnName = column;

        }
    }
}
