using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class Login : IQuery
    {
        private string m_database;
        private string m_name;
        private string m_password;
        public Login(string database,string name, string password)
        {
            m_name = name;
            m_password = password;
            m_database = database;

        }


        public string Run(DB database)
        {
            return database.Login(m_database,m_name,m_password);
        }
    }
    
    
}
