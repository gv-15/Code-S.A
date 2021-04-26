using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Revoke : IQuery
    {
        private string m_profileName;
        private string m_table;
        private string m_privilage;

        public Revoke(string profileName, string tableName, string privilage)
        {
            m_profileName = profileName;
            m_table = tableName;
            m_privilage = privilage;
        }

        public string Run(DB database)
        {

            // return database.GetSecurity().Revoke(m_profileName, m_table, m_privilage);

            return null;
        }

    }
}
