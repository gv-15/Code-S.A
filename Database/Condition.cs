using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Condition
    {
        public enum Operations { max, min, equals };

        private Enum m_operation;
        private string m_value;
        private string m_columnName;
        public Condition(Enum operation, string value, string column)
        {
            m_operation = operation;
            m_value = value;
            m_columnName = column;
        }

        public string GetOperation()
        {
            return m_operation.ToString();
        }

        public string GetValue()
        {
            return m_value;
        }

        public string GetColumnName()
        {
            return m_columnName;
        }
    }
}