using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
   public class Condition
    {
        public enum Operations {max, min, equals };
       
        private Enum m_operation;
        private String m_value;
        private TableColumn m_columnName;
        public Condition(Enum operation, String value, TableColumn column)
        {
            m_operation = operation;
            m_value = value;
            m_columnName = column;
        }

        public String GetOperation()
        {
            return m_operation.ToString();
        }

        public String GetValue()
        {
            return m_value;
        }

        public TableColumn GetColumnName()
        {
            return m_columnName;
        }
    }
}
