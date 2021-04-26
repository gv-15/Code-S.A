using System;
using System.Collections.Generic;
using System.Text;

namespace Database.MiniSqlParser
{
    public class AddUser: IQuery
    {
        private string m_name;
        private string m_password;
        private string m_profile;
        public AddUser(string name, string password, string profile)
        {
            m_name = name;
            m_password = password;
            m_profile = profile;
        }

        public string Run(DB database)
        {

            // return database.GetSecurity().AddUser(m_name,m_password,m_profile);

            return null;
        }

    }
}
