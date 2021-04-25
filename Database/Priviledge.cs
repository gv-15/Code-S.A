using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Priviledge
    {
        public enum Priviledge_type { DELETE, INSERT, SELECT, UPDATE};

        private Enum m_type;

        private string m_tableName;


        public Priviledge(Enum type, string tName)
        {
            m_type = type;
            m_tableName = tName;
        }

        public string GetTableName()
        {
            return m_tableName;
        }
        public void SetTableName(String name)
        {
            m_tableName = name;
        }
        public string GetPriviledgeType()
        {
            return m_type.ToString();
        }
        public void setPriviledgeType(Enum type)
        {
            m_type = type;
        }
    }
}
