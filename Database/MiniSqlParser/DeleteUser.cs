using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class DeleteUser : IQuery
    {
        private string m_name;
        public DeleteUser(string name)
        {
            m_name = name;
        }

        public string Run(DB database)
        {
            return database.GetSecurity().DeleteUser(m_name);
        }

    }
}
