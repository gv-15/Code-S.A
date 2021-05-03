using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Revoke : IQuery
    {
        private string m_profileName;
        private string m_tableName;
        private string m_priviledfeType;
        public Revoke(string profileName, string tableName, string priviledgeType)
        {
            m_profileName = profileName;
            m_tableName = tableName;
            m_priviledfeType = priviledgeType;
        }

        public string Run(DB database)
        {

            return database.GetSecurity().Revoke(m_profileName, m_tableName, m_priviledfeType);
            
        }

    }
}
